using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Services;

using System.Collections.Generic;
using System;



namespace RushMoney.Application
{
    public class ClientAppService : AppServiceBase<Client>, IClientAppService
    {
        private readonly IClientService _clientService;

        public ClientAppService(IClientService clientService)
            : base(clientService)
        {
            _clientService = clientService;
        }

        public DateTime GetLastLogin(Client client)
        {
            return client.LastLogin;
        }

        public IEnumerable<Account> GetAccounts(Client client)
        {
            return _clientService.GetAccounts(client);
        }
    }
}
