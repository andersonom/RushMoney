using RushMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RushMoney.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        IEnumerable<Transaction> GetDebitTransactions(Client client);       
    }
}
