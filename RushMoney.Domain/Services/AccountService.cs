using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;
using RushMoney.Domain.Interfaces.Services;

namespace RushMoney.Domain.Services
{
    public class AccountService : ServiceBase<Account>, IAccountService
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
        {
            _AccountRepository = accountRepository;
        }
    }
}
