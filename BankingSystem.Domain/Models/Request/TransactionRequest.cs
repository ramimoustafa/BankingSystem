using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.Request
{
    public class TransactionRequest
    {
        public DateTime From { get; set; }  
        public DateTime To { get; set; }    
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
