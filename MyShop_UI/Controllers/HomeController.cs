using Core.Model;
using Data.Model;
using DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop_UI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Product> productRepository;
        IRepositoryBase<Category> categoryRepository;

        public HomeController(IRepositoryBase<Product> prjRepo, IRepositoryBase<Category> catRepo)
        {
            productRepository = prjRepo;
            categoryRepository = catRepo;
        }

        //Listing all products in a closer look to products view listing....
        public ActionResult Index()
        {
            return View(productRepository.GetAllData().ToList());
        }
        //get full detail of particular product.
        public ActionResult Detail(string Id)
        {
            Product prj = productRepository.GetDetail(Id);
            if (prj == null)
                return HttpNotFound();
            else
                return View(prj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}