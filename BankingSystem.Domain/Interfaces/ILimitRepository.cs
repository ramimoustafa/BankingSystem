using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Request;
using BankingSystem.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Interfaces
{
    public interface ILimitRepository : IGenericRepository<Limit>
    {
        List<Limit> GetLimits();
        ResponseModel IsEligible(TransferRequest transferRequest, HttpContext context);

    }
}
