using RushMoney.Domain.Entities;
using System.Collections.Generic;


namespace RushMoney.Application.Interfaces
{
   public interface ITransactionAppService : IAppServiceBase<Transaction>
    {
        IEnumerable<Transaction> SearchByDescription(string description);
    }
}
