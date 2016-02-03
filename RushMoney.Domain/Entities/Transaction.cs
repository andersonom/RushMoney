using System;

namespace RushMoney.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime Date { get; set; }
        public bool IsDebit(Transaction transaction) { return transaction.Value < 0; }
 
    }
}
