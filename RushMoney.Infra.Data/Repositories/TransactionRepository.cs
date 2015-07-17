using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
