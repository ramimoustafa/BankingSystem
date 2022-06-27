using BankingSystem.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.API.Service.Models.Request

{
    [DataContract]
    public class LimitRequest
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public double MinAmount { get; set; }
        [DataMember]
        public double MaxAmount { get; set; }

        [DataMember]
        public int MaxAmountPeriodTypeId { get; set; }

        [DataMember]
        public int MaxAmounPeriodValue { get; set; }

        [DataMember]
        public int ObjectTypeId { get; set; }

        [DataMember]
        public int? ObjectId { get; set; } // Null or UserID or UserTypeID

        [DataMember]
        public bool IsTransferTypeRule { get; set; }

        [DataMember]
        public bool IsAccountTypeRule { get; set; }

        [DataMember]

        public List<LimitTransferTypeRequest>? LimitTransferTypes { get; set; }

        [DataMember]

        public List<LimitAccountTypeRequest>? LimitAccountTypes { get; set; }

        [DataMember]
        public int CurrencyTypeId { get; set; }

        [DataMember]
        public int LocationTypeId { get; set; }

        [DataMember]
        public bool IsActive { get; set; } = true;
    }
}
