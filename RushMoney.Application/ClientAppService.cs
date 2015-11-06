using System.Collections.Generic;
using RushMoney.Domain.Entities;

using RushMoney.Domain.Interfaces.Services;
using RushMoney.Application.Interfaces;
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

        public IEnumerable<Transaction> GetDebitTransactions(Client client)
        {
            return _clientService.GetDebitTransactions(client);
        }
    }
}
