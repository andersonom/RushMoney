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

            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(_categoryAppService.GetById(id));
            return View(categoryViewModel);


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
                var categoryDomain = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
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

            var categoryDomain = _categoryAppService.GetById(id);

            return View(Mapper.Map<Category, CategoryViewModel>(categoryDomain));

        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            try
            {
                var categoryModel = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                _categoryAppService.Update(categoryModel);

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

            var categoryDomain = _categoryAppService.GetById(id);

            return View(Mapper.Map<Category, CategoryViewModel>(categoryDomain));

        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var categoryModel = _categoryAppService.GetById(id);

                _categoryAppService.Remove(categoryModel);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
