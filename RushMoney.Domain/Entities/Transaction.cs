

namespace RushMoney.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
