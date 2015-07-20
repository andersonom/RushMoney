using RushMoney.Domain.Entities;
using System.Collections.Generic;

namespace RushMoney.Domain.Interfaces.Services
{
    public interface ITransactionService : IServiceBase<Transaction>
    {
        IEnumerable<Transaction> SearchByDescription(string description);
    }
}
