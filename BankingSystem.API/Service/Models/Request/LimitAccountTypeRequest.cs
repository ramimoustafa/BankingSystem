using System.Runtime.Serialization;


namespace BankingSystem.API.Service.Models.Request
{

    [DataContract]

    public class LimitAccountTypeRequest
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]

        public int LimitId { get; set; }
        [DataMember]

        public int AccountTypeId { get; set; }
    }
}
