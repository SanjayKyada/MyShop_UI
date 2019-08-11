using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.InMemory;
using Data.Model;

namespace MyShop_UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repository;
        public ProductController()
        {
            repository = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(repository.GetAllProduct() as IQueryable);
        }

        //Add view
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //Add ==>time of submit 
        public ActionResult Add(Product p)
        {
            repository.InsertProduct(p);
            return RedirectToAction("Index");
        }
        // Fetch the detail of record.
        public ActionResult Edit(string Id)
        {
            if (ModelState.IsValid)
                return View(repository.GetProductDetail(Id));
            else
                throw new Exception("Invalid Model");
        }
        // For Updating Product details
        [HttpPost]
        public ActionResult Edit(Product newProductObj)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateProduct(newProductObj);
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception("Invalid Model");
            }
        }
        // for redirecting Confirm delete page.
        public ActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                return View(repository.GetProductDetail(id));
            }
            else
            {
                throw new Exception("Invalid Model");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteProduct(id);
                return RedirectToAction("index");
            }
            else
            {
                throw new Exception("Invalid Model");
            }
        }

    }
}