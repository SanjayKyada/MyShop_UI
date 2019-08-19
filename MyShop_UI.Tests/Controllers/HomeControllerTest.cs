using Core.Contract;
using Core.Model;
using Core.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop_UI.Tests.Mocks;
using System.Web.Mvc;

namespace MyShop_UI.Tests.Controllers
{
    [TestClass]
    public class _HomeControllerTest
    {
        [TestMethod]
        public void ContextTesting()
        {
            IRepositoryBase<Product> prjObj = new ContextTest<Product>();
            IRepositoryBase<Category> catObj = new ContextTest<Category>();

            prjObj.Add(new Product());

            MyShop_UI.Controllers.HomeController homeController = new MyShop_UI.Controllers.HomeController(prjObj, catObj);
            ViewResult results = homeController.Index() as ViewResult;
            var model = (ProductListViewModel)results.ViewData.Model;

            Assert.AreEqual(1, model.ProductObj.Count);
        }

    }
}
