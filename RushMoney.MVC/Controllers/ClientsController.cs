﻿using System.Web.Mvc;
using AutoMapper;
using System.Collections;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;
using System.Collections.Generic;

using RushMoney.Application.Interfaces;

namespace RushMoney.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientAppService _clientAppService;
        private readonly ITransactionAppService _transactionAppService;

        public ClientsController(IClientAppService clientAppService, ITransactionAppService transactionAppService)
        {
            _clientAppService = clientAppService;
            _transactionAppService = transactionAppService;
        }

        // GET: Clients
        public ActionResult Index()
        {
            var clientViewModel = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientAppService.GetAll());

            return View(clientViewModel);
        }

        // GET: Clients
        public ActionResult Transactions(ClientViewModel client)
        {

            var transactionViewModel = Mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionViewModel>>(_clientAppService.GetDebitTransactions(Mapper.Map<ClientViewModel, Client>(client)));

            return View(transactionViewModel);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var client = _clientAppService.GetById(id);

            return View(Mapper.Map<Client, ClientViewModel>(client));
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);

                _clientAppService.Add(clientDomain);

                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientAppService.GetById(id);

            return View(Mapper.Map<Client, ClientViewModel>(client));
        }

        // POST: Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);

                _clientAppService.Update(clientDomain);

                return RedirectToAction("Index");
            }

            return View(client);

        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _clientAppService.GetById(id);

            return View(Mapper.Map<Client, ClientViewModel>(client));
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ClientViewModel client)
        {
            try
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);

                _clientAppService.Remove(clientDomain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
