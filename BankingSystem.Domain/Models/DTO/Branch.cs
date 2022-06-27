using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BankingSystem.Domain.Models.DTO
{
    [Index(nameof(Name), IsUnique = true, Name = "Unique_Branch_Name")]

    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<User> Users { get; set; }

    }
}
