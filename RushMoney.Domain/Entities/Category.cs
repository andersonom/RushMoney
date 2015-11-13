using System;
using System.Collections.Generic;


namespace RushMoney.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public bool IsActive { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }

    }
}
