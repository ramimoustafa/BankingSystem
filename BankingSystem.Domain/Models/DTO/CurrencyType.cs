using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.DTO
{
    public class CurrencyType
    {
        public int Id { get; set; }
        public string Name { get; set; }    

    }

    public enum CurrencyTypeEnum
    {
        Same=1,
        Different=2
    }
}
