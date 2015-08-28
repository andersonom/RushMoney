using System;
using System.Collections;
using System.Collections.Generic;
using RushMoney.Domain.Entities;

namespace RushMoney.Domain.Interfaces.Services
{
    public interface IClientService : IServiceBase<Client>
    {
        DateTime GetLastLogin(Client client);
        IEnumerable<Transaction> GetDebitTransactions(Client client);
    }
}
