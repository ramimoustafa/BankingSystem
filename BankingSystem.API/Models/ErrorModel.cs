namespace BankingSystem.API.Models
{
    public class ErrorModel
    {
        public string? FieldName { get; set; }
        public string? Message { get; set; }
    }
    
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
