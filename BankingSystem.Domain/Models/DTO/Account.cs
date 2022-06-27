using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
 
namespace BankingSystem.Domain.Models.DTO
{
    [Index(nameof(Number), IsUnique = true, Name = "Unique_Account_Name")]

    public class Account
    {
        [Key]
        public int? Id { get; set; }
        public int Number { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [ForeignKey("AccountType")]
        public int AccountTypeId { get; set; }
        public AccountType? AccountType { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }


        [DefaultValue(true)]
        public bool IsActive { get; set; }


        [Column(TypeName = "Datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }  

        public ICollection<Transaction> SourceTransactions{ get; set; }
        public ICollection<Transaction> DestinationTransactions { get; set; }
    }


}
