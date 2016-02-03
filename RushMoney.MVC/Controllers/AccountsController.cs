using AutoMapper;
using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;

using System.Collections.Generic;
using System.Web.Mvc;

namespace RushMoney.MVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountAppService _accountAppService;
        private readonly IClientAppService _clientAppService;

        public AccountsController(IAccountAppService accountAppService, IClientAppService clientAppService)
        {
            _accountAppService = accountAppService;
            _clientAppService = clientAppService;
        }

        // GET: Account
        public ActionResult Index()
        {
            var accountViewModel = Mapper.Map<IEnumerable<Account>, IEnumerable<AccountViewModel>> (_accountAppService.GetAll());
            return View(accountViewModel);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            var accountDomain = _accountAppService.GetById(id);

            return View(Mapper.Map<Account, AccountViewModel>(accountDomain));
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "Id", "FirstName");
            
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var accountDomain = Mapper.Map<AccountViewModel, Account>(account);
                _accountAppService.Add(accountDomain);

                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            var accountDomain =_accountAppService.GetById(id);
            return View(Mapper.Map<Account,AccountViewModel>(accountDomain));
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(AccountViewModel accountViewModel)
        {
            try
            {
                var accountDomain = Mapper.Map<AccountViewModel,Account>(accountViewModel);
                _accountAppService.Update(accountDomain);               

                return RedirectToAction("Index");
            }
            catch
            {
                return View(accountViewModel);
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            var accountDomain = _accountAppService.GetById(id);

            return View(Mapper.Map<Account,AccountViewModel>(accountDomain));
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //var _transacitonAppSerivce = new RushMoney.Application.Interfaces.ITransactionAppService();
                //if (_accountAppService.Tra
                //{

                //}
                var accountDomain = _accountAppService.GetById(id);

                _accountAppService.Remove(accountDomain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
