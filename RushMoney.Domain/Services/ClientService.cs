using System.Linq;
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
            return client.LastLogin;
        }

        public IEnumerable<Transaction> GetDebitTransactions(Client client)
        {
            return client.Transactions.Where(i => i.IsDebit(i));
        }
    }
}
