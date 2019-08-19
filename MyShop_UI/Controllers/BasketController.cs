using Core.Contract;
using System.Web.Mvc;

namespace MyShop_UI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService BasketService;

        public BasketController(IBasketService basketService)
        {
            BasketService = basketService;
        }

        // GET: Basket
        public ActionResult Index()
        {
            return View(BasketService.GetAllBasketItems(this.HttpContext));
        }

        //Adding items into basket/cart.
        //If same product then increase qty, otherwise add into basket.
        public ActionResult AddInBasket(string ProductId)
        {
            BasketService.AddProductInBasket(this.HttpContext, ProductId);
            return RedirectToAction("Index");
        }

        //Delete Whole Item from Basket.==>This Method doesn't intend to create for reducing quanty.
        public ActionResult DeleteItemFromBasket(string ItemID)
        {
            BasketService.RemoveProductFromBasket(this.HttpContext, ItemID);
            return RedirectToAction("Index");
        }

        //Get a basket Summary...Partial view...
        public PartialViewResult BasketSummary()
        {
            return PartialView(BasketService.GetBasketSummary(this.HttpContext));
        }

    }
}