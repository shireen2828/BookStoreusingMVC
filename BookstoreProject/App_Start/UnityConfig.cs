using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using RepositoryLayer.Interaces;
using RepositoryLayer.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BookstoreProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IBooksManager, BooksManager>();
            container.RegisterType<ICartManager, CartManager>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IBooksRepository, BooksRepository>();            
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<IWishlistManager, WishlistManager>();
            container.RegisterType<IWishlistRepository, WishlistRepository>();
            

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
        }
    }
}