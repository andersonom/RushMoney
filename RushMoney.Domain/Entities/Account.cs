using System;
using System.Collections.Generic;


namespace RushMoney.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public bool IsActive { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }

    }
}
