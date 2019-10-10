using lendit.Model;

namespace lendit.DTOs
{
    public class BorrowerApplicationDTO
    {
        public string UserHash { get; set; }
        public string username {get; set;}
        public string CreditScore {get; set; }
        
        public LenderPool LenderPool {get; set;}
    }
}