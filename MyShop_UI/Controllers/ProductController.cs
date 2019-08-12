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
        Product_Dynamic<Product> repository;
        public ProductController()
        {
            repository = new Product_Dynamic<Product>();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(repository.GetAllData().ToList());
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
            repository.Add(p);
            repository.Commit();
            return RedirectToAction("Index");
        }
        // Fetch the detail of record.
        public ActionResult Update(string Id)
        {
            if (ModelState.IsValid)
                return View("Edit", repository.GetDetail(Id));
            else
                throw new Exception("Invalid Model");
        }

        //// For Edit Product details==>conventional way to update product.
        //[HttpPost]
        //public ActionResult EditProduct(Product newProductObj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.UpdateProduct(newProductObj);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid Model");
        //    }
        //}




        // For Updating Product details
        [ActionName("Update")]
        [HttpPost]
        public ActionResult UpdateProduct(Product newProductObj, string id)
        {
            if (ModelState.IsValid)
            {
                Product oldProduct = repository.GetDetail(id);
                oldProduct.Category = newProductObj.Category;
                oldProduct.Description = newProductObj.Description;
                oldProduct.Image = newProductObj.Image;
                oldProduct.Name = newProductObj.Name;
                oldProduct.Price = newProductObj.Price;

                //oldProduct = newProductObj.ShallowCopy();
                repository.Commit();

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
                return View(repository.GetDetail(id));
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
                repository.DeleteObject(id);
                return RedirectToAction("index");
            }
            else
            {
                throw new Exception("Invalid Model");
            }
        }

    }
}