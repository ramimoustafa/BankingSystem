using BankingSystem.Domain.Interfaces;
using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Request;
using BankingSystem.Domain.Models.Response;
using BankingSystem.Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;


        public UserController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;

        }
        [HttpGet]
        public IActionResult GetActiveAccountsUsers( )
        {
            List<UserResponse> userResponses = _unitOfWork.Users.GetActiveAccountsUsers(_configuration.GetConnectionString("BankingSystem"));
            ResponseModel response = Helper.ReturnResponse(500, "Retrieved Succesffuly", userResponses, HttpContext);
            return new JsonResult(response);
        }
       

    }
}
