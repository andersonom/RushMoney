using System.Linq;
using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;
using RushMoney.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RushMoney.Domain.Services
{
    public class TransactionService : ServiceBase<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
            : base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> SearchByDescription(string description)
        {
            return _transactionRepository.SearchByDescription(description);
        }

        public IEnumerable<Transaction> GetDebitTransactions(IEnumerable<Transaction> transactions)
        {
            return transactions.Where(c => c.IsDebit(c)); //Should use _clientRepository.method in order to make sense of using this layer
        }
    }
}
