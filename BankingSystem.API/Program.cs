using BankingSystem.API.Exceptions;
using BankingSystem.API.Service;
using BankingSystem.Domain.Interfaces;
using BankingSystem.Infrastructure;
using BankingSystem.Infrastructure.Repositories;
using BankingSystem.API.Filters;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
 using SoapCore;
 using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingSystem"));
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
});
builder.Services.AddFluentValidation(mvcConfiguration =>
mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Program>());



builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ILimitRepository, LimitRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddSoapCore();
builder.Services.AddScoped<ISoapService,SoapService>();
 
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.UseSoapEndpoint<ISoapService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);

//});
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ISoapService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);

});



app.Run();
