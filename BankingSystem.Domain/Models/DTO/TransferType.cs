using System;
 using Microsoft.EntityFrameworkCore;
 
namespace BankingSystem.Domain.Models.DTO
{
    [Index(nameof(Name), IsUnique = true, Name = "Unique_TransferType_Name")]

    public class TransferType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LimitTransferType>? LimitTransferTypes { get; set; }


    }

    public enum TransferEnum
    {
        Own,
        Other
    }
}
