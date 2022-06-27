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
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;



        public TransactionController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;

        }


        [HttpGet]
        public IActionResult GetTransactions([FromBody] TransactionRequest transactionRequest )
        {
           
            List<TransactionResponse> transactionResponses = _unitOfWork.Transactions.GetTransactions(transactionRequest, _configuration.GetConnectionString("BankingSystem"));
            ResponseModel response = Helper.ReturnResponse(500, "Retrieved Succesffuly", transactionResponses, HttpContext);
            return new JsonResult(response);
        }
    }
}
