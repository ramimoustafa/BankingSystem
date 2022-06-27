using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.Request
{
 

    public class TransferRequest
    {
        public int SourceAccountNumber { get; set; }
        public int DestinationAccountNumber { get; set; }
        public int TransferTypeId { get; set; }
        public double Amount { get; set; }
    }
}
