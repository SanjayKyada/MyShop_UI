using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.InMemory;
using Data.Model;
using Core.Model;
using Core.ViewModel;
using System.IO;

namespace MyShop_UI.Controllers
{
    public class ProductController : Controller
    {
        IRepositoryBase<Product> repository;
        IRepositoryBase<Category> categories;
        public ProductController(IRepositoryBase<Product> productObj, IRepositoryBase<Category> categoryObj)
        {
            repository = productObj;
            categories = categoryObj;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(repository.GetAllData().ToList());
        }

        //Add view
        public ActionResult Add()
        {
            Product productObj = new Product();
            List<Category> categoryList = categories.GetAllData().ToList();

            ProductCategoryModel viewModel = new ProductCategoryModel()
            {
                ProductObj = productObj,
                CategoryListObj = categoryList
            };
            return View(viewModel);
        }
        [HttpPost]
        //Add ==>time of submit 
        public ActionResult Add(ProductCategoryModel p, HttpPostedFileBase fileObj)
        {
            if (fileObj != null)
            {
                p.ProductObj.Image = p.ProductObj.Id + fileObj.FileName + Path.GetExtension(fileObj.FileName);
                fileObj.SaveAs(Server.MapPath("//Content//ProductImages//" + p.ProductObj.Image));
            }
            repository.Add(p.ProductObj);
            repository.Commit();
            return RedirectToAction("Index");
        }
        // Fetch the detail of record.
        public ActionResult Update(string Id)
        {
            if (ModelState.IsValid)
            {
                Product productObj = repository.GetDetail(Id);

                List<Category> categoryList = categories.GetAllData().ToList();

                ProductCategoryModel viewModel = new ProductCategoryModel()
                {
                    ProductObj = productObj,
                    CategoryListObj = categoryList
                };
                return View("Edit", viewModel);
            }
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
        public ActionResult UpdateProduct(ProductCategoryModel newProductObj, string id, HttpPostedFileBase fileObj)
        {
            if (ModelState.IsValid)
            {
                Product oldProduct = repository.GetDetail(id);

                string ImageFileName = newProductObj.ProductObj.Image;
                if (fileObj != null)
                {
                    ImageFileName = newProductObj.ProductObj.Id + fileObj.FileName + Path.GetExtension(fileObj.FileName);
                    fileObj.SaveAs(Server.MapPath("//Content//ProductImages//") + ImageFileName);
                }

                oldProduct.Category = newProductObj.ProductObj.Category;
                oldProduct.Description = newProductObj.ProductObj.Description;
                oldProduct.Image = ImageFileName;
                oldProduct.Name = newProductObj.ProductObj.Name;
                oldProduct.Price = newProductObj.ProductObj.Price;

                //oldProduct = newProductObj.ShallowCopy();
                repository.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

                throw new Exception(errors.ToString());
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
                repository.Commit();
                return RedirectToAction("index");
            }
            else
            {
                throw new Exception("Invalid Model");
            }
        }

    }
}