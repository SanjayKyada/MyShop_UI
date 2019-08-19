using Core.ViewModel;
using System.Collections.Generic;
using System.Web;

namespace Core.Contract
{
    public interface IBasketService
    {
        void AddProductInBasket(HttpContextBase contextBaseObj, string productID);
        List<BasketProductViewModel> GetAllBasketItems(HttpContextBase contextBase);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase contextBase);
        void RemoveProductFromBasket(HttpContextBase contextBase, string basketItemID);
    }
}