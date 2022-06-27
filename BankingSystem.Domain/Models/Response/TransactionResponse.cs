using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.Response
{
    public class TransactionResponse
    {
        public int? Id { get; set; }
        public int SourceAccountNumber { get; set; }
        public int DestinationAccountNumber { get; set; }
        public double Amount { get; set; }
        public DateTime Created { get; set; }
    }

}
