using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.DTO
{
    public class PeriodType
    {
        public int Id { get; set; }
        public string Name { get; set; }    

    }

    public enum PeriodTypeEnum
    {
        Minutes,
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
}
