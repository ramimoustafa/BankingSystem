using BankingSystem.API.Service.Models.Request;
using BankingSystem.API.Service.Models.Response;
using BankingSystem.Domain.Models.DTO;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.API.Service
{
    [ServiceContract, XmlSerializerFormat]
    public interface ISoapService
    {

        [OperationContract]
        public LimitRequest InsertOrUpdateLimits(LimitRequest limit);

        [OperationContract]

        public List<UserResponse> GetInactiveAccountsUsers();

        [OperationContract]
        public List<UserResponse> GetReachedUsers(int limitId);

    }
}
