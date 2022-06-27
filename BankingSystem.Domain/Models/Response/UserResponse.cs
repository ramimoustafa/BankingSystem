using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.Response
{
    
    public class UserResponse
    {
        
        public int? Id { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? MiddleName { get; set; }
        
        public DateTime DOB { get; set; }
        
        public String Gender { get; set; }
        
        public String UserType { get; set; }
        
        public String Branch { get; set; }
        
        public DateTime Created { get; set; }
    }
}
