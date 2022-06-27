using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Domain.Models.DTO
{
    [Index(nameof(Name),  IsUnique = true, Name = "Unique_AccountType_Name")]
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<LimitAccountType>? LimitAccountTypes { get; set; }
    }

    public enum AccountEnum
    {
        Current,
        Fresh,
        TimeDeposit
    }

}
