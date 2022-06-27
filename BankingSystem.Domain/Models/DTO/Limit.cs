using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Domain.Models.DTO
{
    public class Limit
    {
        [Key]
        public int? Id { get; set; }
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }

        [ForeignKey("MaxAmountPeriodType")]
        public int MaxAmountPeriodTypeId { get; set; }
        public PeriodType? MaxAmountPeriodType { get; set; }
        public int MaxAmounPeriodValue { get; set; }

        [ForeignKey("ObjectType")]
        public int? ObjectTypeId { get; set; }   
        public ObjectType? ObjectType { get; set; }

        public int? ObjectId { get; set; } // Null or UserID or UserTypeID

        public bool IsTransferTypeRule { get; set; }
        public bool IsAccountTypeRule { get; set; }

        public List<LimitTransferType>? LimitTransferTypes { get; set; }

        public List<LimitAccountType>? LimitAccountTypes { get; set; }

        [ForeignKey("CurrencyType")]
        public int CurrencyTypeId { get; set; }
        public CurrencyType? CurrencyType { get; set; }

        [ForeignKey("LocationType")]
        public int LocationTypeId { get; set; }
        public LocationType? LocationType { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

    }

    public enum ObjectTypEnum
    {
         
        User =1,
        UserType =2
    }


    //public enum LocationType
    //{
    //    Source,
    //    Destination,
    //    Both
    //}

    //public enum CurrencyType
    //{
    //    Same,
    //    Different,
    //    None
    //}

}
