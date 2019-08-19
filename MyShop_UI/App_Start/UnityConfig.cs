using Core.Contract;
using Core.Model;
using DataAccess.SQL;
using Service;
using System;

using Unity;

namespace MyShop_UI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.

            //==> Below lines are used for solve ==> Passing object's in controller at runtime in their constructor.
            container.RegisterType<IRepositoryBase<Product>, SqlRepository<Product>>();
            container.RegisterType<IRepositoryBase<Category>, SqlRepository<Category>>();
            container.RegisterType<IRepositoryBase<Basket>, SqlRepository<Basket>>();
            container.RegisterType<IRepositoryBase<BasketItem>, SqlRepository<BasketItem>>();
            container.RegisterType<IBasketService, BasketService>();

        }
    }
}