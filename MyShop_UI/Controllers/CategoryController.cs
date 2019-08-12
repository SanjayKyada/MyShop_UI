using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.InMemory;

namespace MyShop_UI.Controllers
{
    public class CategoryController : Controller
    {
        Product_Dynamic<Category> categories;

        public CategoryController()
        {
            categories = new Product_Dynamic<Category>();
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(categories.GetAllData().ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                categories.Add(categoryObj);
                categories.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(string ID)
        {
            if (ModelState.IsValid)
                return View(categories.GetDetail(ID));
            else
                return View();
        }

        [HttpPost]
        public ActionResult Edit(Category newCatObj, string Id)
        {
            if (ModelState.IsValid)
            {
                Category oldCategory = categories.GetDetail(Id);
                oldCategory.Name = newCatObj.Name;
                categories.Commit();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public ActionResult Delete(string ID)
        {
            if (ModelState.IsValid)
            {
                return View(categories.GetDetail(ID));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            if (ModelState.IsValid)
            {
                categories.DeleteObject(ID);
                categories.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}