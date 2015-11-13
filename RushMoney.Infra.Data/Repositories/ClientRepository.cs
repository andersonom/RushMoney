using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RushMoney.Infra.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public IEnumerable<Account> GetAccounts(Client client)
        {
            return Db.Accounts.Where(i => i.ClientId.Equals(client.Id)); // && i.IsDebit(i)
        }
    }
}
