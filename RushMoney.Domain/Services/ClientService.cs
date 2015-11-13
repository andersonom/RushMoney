using System;
using System.Collections.Generic;
using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;
using RushMoney.Domain.Interfaces.Services;

namespace RushMoney.Domain.Services
{
    public class ClientService : ServiceBase<Client> , IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
            : base(clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        public DateTime GetLastLogin(Client client)
        { 
            return client.LastLogin;  //Should use _clientRepository.method in order to make sense of using this layer
        }

        public IEnumerable<Account> GetAccounts(Client client)
        {
            return client.Accounts;//.Where(i => i.IsDebit(i));    //Should use _clientRepository.method in order to make sense of using this layer
        }
    }
}
