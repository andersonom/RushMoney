using System;
using System.Collections.Generic;

namespace RushMoney.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
        
        public DateTime GetLastLogin(Client client)
        {
            return client.LastLogin;
        }
    }
}
