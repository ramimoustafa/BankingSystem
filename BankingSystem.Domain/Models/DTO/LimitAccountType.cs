using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.DTO
{
    [Index(nameof(LimitId), nameof(AccountTypeId), IsUnique = true, Name = "Unique_LimitAccountType")]

    public class LimitAccountType
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Limit")]
        public int LimitId { get; set; }
        public Limit? Limit { get; set; }

        [ForeignKey("AccountType")]
        public int AccountTypeId { get; set; }
        public AccountType? AccountType { get; set; }
    }
}
