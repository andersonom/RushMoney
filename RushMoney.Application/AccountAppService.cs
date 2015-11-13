using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Services;

namespace RushMoney.Application
{
    public class AccountAppService : AppServiceBase<Account>, IAccountAppService
    {
        private readonly IAccountService _accountService;

        public AccountAppService(IAccountService accountService) : base (accountService)
        {
            _accountService = accountService;
        }        
    }
}
