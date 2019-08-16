using Core.Model;
using Core.ViewModel;
using Data.Model;
using DataAccess.InMemory;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<Category> categories = categoryRepository.GetAllData().ToList();

            if (Category == null)
                products = productRepository.GetAllData().ToList();
            else
                products = productRepository.GetAllData().Where(x => x.Category == Category).ToList();

            ProductListViewModel model = new ProductListViewModel()
            {
                CategoryListObj = categories,
                ProductObj = products
            };
            return View(model);
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