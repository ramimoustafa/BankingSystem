using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Models.DTO
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        [ForeignKey("Gender")]

        public int GenderId { get; set; }
        public Gender? Gender { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public UserType? UserType { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

        [Column(TypeName = "Datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? Created { get; set;  }  
        public virtual ICollection<Account>? Accounts { get; set; }


    }

    //public enum Gender
    //{
    //    Male = 1,
    //    Female = 2
    //}
    //public enum UserType
    //{
    //    Individual = 1,
    //    Corporate = 2,
    //    Military = 3,
    //    VIP = 4
    //}


}
