using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;

namespace RushMoney.Infra.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
    }
}
