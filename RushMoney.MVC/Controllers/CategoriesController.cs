using AutoMapper;
using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RushMoney.MVC.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryAppService _categoryAppService;
        
        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;

        }
        // GET: Category
        public ActionResult Index()
        {
            var listCategoryDomain = _categoryAppService.GetAll();
            var categoryViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(listCategoryDomain);
            return View(categoryViewModel);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            try
            {                
                var categoryDomain= Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                _categoryAppService.Add(categoryDomain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
