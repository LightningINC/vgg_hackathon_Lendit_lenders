using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lendit.Model
{
    public class User
    {
        public int UserId { get; set; }
        [Key]
        public string UserHash { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public int AccountNo { get; set; }
        public string Bank { get; set; }
        public Wallet Wallet {get; set;}
        public ICollection<TransactionEntity> TransactionEntity { get; set; }
        public Eligibility Eligibility {get; set;}
        public ICollection<LenderPool> LenderPool {get; set;}
        public ICollection<LenderBorrowerTransaction> LenderTransaction { get; set; }
        public ICollection<LenderBorrowerTransaction> BorrowerTransaction {get; set;}
    


    }
}