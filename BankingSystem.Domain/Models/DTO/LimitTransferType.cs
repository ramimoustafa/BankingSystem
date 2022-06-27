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

    [Index(nameof(LimitId), nameof(TransferTypeId), IsUnique = true, Name = "Unique_LimitTransferType")]

    public class LimitTransferType
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Limit")]
        public int LimitId { get; set; }
        public Limit? Limit { get; set; }

        [ForeignKey("TransferType")]
        public int TransferTypeId { get; set; }
        public TransferType? TransferType { get; set; }
    }
}
