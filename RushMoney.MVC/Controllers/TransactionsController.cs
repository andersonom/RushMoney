using AutoMapper;
using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RushMoney.MVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionAppService _transactionAppService;
        private readonly IClientAppService _clientAppService;

        public TransactionsController(ITransactionAppService transactionAppService, IClientAppService clientAppService)
        {
            _transactionAppService = transactionAppService;
            _clientAppService = clientAppService;
        }

        // GET: Transactions
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionViewModel>>(_transactionAppService.GetAll()));
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int id)
        {
            var transaction = _transactionAppService.GetById(id);

            return View(Mapper.Map<Transaction, TransactionViewModel>(transaction));
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {

            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "Id", "FirstName");

            return View();

        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                var transactionDomain = Mapper.Map<TransactionViewModel, Transaction>(transaction);

                _transactionAppService.Add(transactionDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "ClientId", "FirstName",transaction.ClientId);

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "Id", "FirstName");

            var transaction = _transactionAppService.GetById(id);

            return View(Mapper.Map<Transaction, TransactionViewModel>(transaction));
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        public ActionResult Edit(TransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                var transactionDomain = Mapper.Map<TransactionViewModel, Transaction>(transaction);

                _transactionAppService.Update(transactionDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "ClientId", "FirstName", transaction.ClientId);

            return View(transaction);

        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int id)
        {
            var transaction = _transactionAppService.GetById(id);

            return View(Mapper.Map<Transaction, TransactionViewModel>(transaction));
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TransactionViewModel transaction)
        {
            try
            {
                var transactionDomain = Mapper.Map<TransactionViewModel, Transaction>(transaction);

                _transactionAppService.Remove(transactionDomain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}