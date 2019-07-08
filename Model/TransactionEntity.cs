using System;

namespace lendit.Model
{
    public class TransactionEntity
    {
        public int TransactionEntityId {get; set;}

        public DateTime Date { get; set; }
        public int Amount { get; set; }

        public string UserHash {get; set;}
        public User User { get; set; }
    }
}