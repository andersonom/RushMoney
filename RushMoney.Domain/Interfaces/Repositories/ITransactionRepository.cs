using RushMoney.Domain.Entities;
using System.Collections.Generic;

namespace RushMoney.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        IEnumerable<Transaction> SearchByDescription(string Description);
    }
}
