using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.API.Service.Models.Response

{
    [DataContract]
    public class UserResponse
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string? FirstName { get; set; }
        [DataMember]
        public string? LastName { get; set; }
        [DataMember]
        public string? MiddleName { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public String Gender { get; set; }
        [DataMember]
        public String UserType { get; set; }
        [DataMember]
        public String Branch { get; set; }
        [DataMember]
        public DateTime? Created { get; set; }
    }
}
