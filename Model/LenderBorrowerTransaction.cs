using System.ComponentModel.DataAnnotations.Schema;

namespace lendit.Model
{
    public class LenderBorrowerTransaction
    {
        public int LenderBorrowerTransactionId { get; set; } 
        public string Status { get; set; }
        public int Amount { get; set; }

        public string LenderHash {get; set;}
        public User Lender {get; set;}
        public string BorrowHash {get; set;}
        public User Borrower{get; set;}
    }
}