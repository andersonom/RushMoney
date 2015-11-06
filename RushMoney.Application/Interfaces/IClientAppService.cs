using RushMoney.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RushMoney.Application.Interfaces
{
   public interface IClientAppService : IAppServiceBase<Client>
    {
        DateTime GetLastLogin(Client client);
        IEnumerable<Transaction> GetDebitTransactions(Client client);
    }
}
