using RushMoney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushMoney.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        IEnumerable<Transaction> SearchByDescription(string Description);
    }
}
