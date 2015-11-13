using System;
using RushMoney.Domain.Entities;
using System.Collections.Generic;

namespace RushMoney.Domain.Interfaces.Services
{
    public interface IClientService : IServiceBase<Client>
    {
        DateTime GetLastLogin(Client client);
        IEnumerable<Account> GetAccounts(Client client);
    }
}
