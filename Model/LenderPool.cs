using System;

namespace lendit.Model
{
    public class LenderPool
    {
        public int LenderPoolId { get; set; }
        public string LenderHash { get; set; }
        public User Lender{get; set;}
        public int InterestRate { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
}