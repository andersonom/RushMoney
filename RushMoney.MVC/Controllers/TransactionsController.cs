using AutoMapper;
using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;
using System.Collections.Generic;

using System.Web.Mvc;

namespace RushMoney.MVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionAppService _transactionAppService;
        private readonly IAccountAppService _accountAppService;
        private readonly ICategoryAppService _categoryAppService;
        public TransactionsController(ITransactionAppService transactionAppService, IAccountAppService accountAppService, ICategoryAppService categoryAppService)
        {
            _transactionAppService = transactionAppService;
            _accountAppService = accountAppService;
            _categoryAppService = categoryAppService;
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
            ViewBag.CategoryId = new SelectList(_categoryAppService.GetAll(), "Id", "Name");
            ViewBag.AccountId = new SelectList(_accountAppService.GetAll(), "Id", "Name");

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
          
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int id)
        {
            var transaction = _transactionAppService.GetById(id);

            ViewBag.AccountId = new SelectList(_accountAppService.GetAll(), "Id", "Name",transaction.AccountId);
            ViewBag.CategoryId = new SelectList(_categoryAppService.GetAll(), "Id", "Name", transaction.CategoryId);            

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

            ViewBag.AccountId= new SelectList(_accountAppService.GetAll(), "Id", "Name", transaction.AccountId);

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