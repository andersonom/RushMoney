using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace RushMoney.Infra.Data.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {

        public IEnumerable<Transaction> SearchByDescription(string Description)
        {
            return Db.Transactions.Where(p => p.Description == Description);
        }
    }
}
