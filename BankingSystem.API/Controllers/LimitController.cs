using BankingSystem.Domain.Interfaces;
using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Request;
using BankingSystem.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public LimitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public List<Limit> GetLimits()
        {
            return _unitOfWork.Limits.GetLimits();
        }

        [HttpPost]
        [Route("IsEligible")]
        public IActionResult IsEligible(TransferRequest transferRequest)
        {
            ResponseModel responseModel = _unitOfWork.Limits.IsEligible(transferRequest, HttpContext);

            return new JsonResult(responseModel);
        }

    }
}
