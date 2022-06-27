using Microsoft.EntityFrameworkCore;


namespace BankingSystem.Domain.Models.DTO
{
    [Index(nameof(Name), IsUnique = true, Name = "Unique_Currency_Name")]
    [Index(nameof(Code), IsUnique = true, Name = "Unique_Currency_Code")]

    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

  
}
