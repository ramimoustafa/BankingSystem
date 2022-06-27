using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.DTO
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int? SourceAccountNumber { get; set; }

        public int? DestinationAccountNumber { get; set; }

        //[ForeignKey("SourceAccountId")]
        public Account? SourceAccount { get; set; }

        //[ForeignKey("DestinationAccountId")]
        public Account? DestinationAccount { get; set; }
        public double Amount { get; set; }

        [Column(TypeName = "Datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
