using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RushMoney.Application
{
    public class TransactionAppService : AppServiceBase<Transaction>, ITransactionAppService
    {
        private readonly ITransactionService _transactionService;

        public TransactionAppService(ITransactionService transactionService) : base (transactionService)
        {
            _transactionService = transactionService;
        }

        public IEnumerable<Transaction> SearchByDescription(string description)
        {
            return _transactionService.SearchByDescription(description);
        }

    }
}
