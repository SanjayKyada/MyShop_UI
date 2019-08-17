using Core.Model;
using Data.Model;
using DataAccess.InMemory;
using System.Web;
using System;
using System.Linq;

namespace Service
{
    public class BasketService
    {
        IRepositoryBase<Product> productCollection;
        IRepositoryBase<Basket> basketCollection;
        public const string CookieName = "MyShopBasket";

        public BasketService(IRepositoryBase<Product> productCollection,
                                     IRepositoryBase<Basket> basketCollection)
        {
            this.productCollection = productCollection;
            this.basketCollection = basketCollection;
        }

        /// <summary>
        /// gives you basket to store basket items.
        /// </summary>
        /// <param name="contextBase"></param>
        /// <param name="isNewBasketRequired">true will give you new blank basket to store basket items.</param>
        /// <returns></returns>
        private Basket GetBasket(HttpContextBase contextBase, bool isNewBasketRequired)
        {
            HttpCookie cookieObj = contextBase.Request.Cookies.Get(CookieName);

            Basket basketObj = new Basket();
            if (cookieObj != null)
            {
                string basketID = cookieObj.Value;
                if (!string.IsNullOrEmpty(basketID))
                {
                    basketObj = basketCollection.GetDetail(basketID);
                }
                else
                {
                    if (isNewBasketRequired)
                        basketObj = CreateNewBasketAndCookie(contextBase);
                }
            }
            else
            {
                if (isNewBasketRequired)
                    basketObj = CreateNewBasketAndCookie(contextBase);
            }
            return basketObj;
        }

        //To create new basket and add cookies into browser.
        private Basket CreateNewBasketAndCookie(HttpContextBase contextBase)
        {
            Basket basketNewobj = new Basket();
            basketCollection.Add(basketNewobj);
            basketCollection.Commit();

            HttpCookie cookie = new HttpCookie(CookieName);
            cookie.Value = basketNewobj.Id;
            cookie.Expires = DateTime.Now.AddDays(-1);
            contextBase.Response.Cookies.Add(cookie);
            return basketNewobj;
        }

        //Add another qty +1 in product of basket item if already exist, otherwise show 1 qty and add product.
        public void AddProductInBasket(HttpContextBase contextBaseObj, string productID)
        {
            Basket basketObj = GetBasket(contextBaseObj, true);
            BasketItem basketItemObj = basketObj.BasketList.FirstOrDefault(x => x.ProductId == productID);
            if (basketItemObj != null)
            {
                basketItemObj.Qty = basketItemObj.Qty + 1;
            }
            else
            {
                basketItemObj = new BasketItem()
                {
                    ProductId = productID,
                    BucketId = basketObj.Id,
                    Qty = 1
                };
                basketObj.BasketList.Add(basketItemObj);
            }

            basketCollection.Commit();
        }

        //Remove one item from basket list.
        public void RemoveProductFromBasket(HttpContextBase contextBase, string basketItemID)
        {
            Basket basketObj = GetBasket(contextBase, true);
            BasketItem basketItem = basketObj.BasketList.FirstOrDefault(x => x.BucketId == basketItemID);

            if (basketItem != null)
            {
                basketObj.BasketList.Remove(basketItem);
                basketCollection.Commit();
            }
        }
    }

}

