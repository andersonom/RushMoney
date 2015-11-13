using RushMoney.Domain.Entities;
using System.Collections.Generic;

namespace RushMoney.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        IEnumerable<Account> GetAccounts(Client client);
    }
}
