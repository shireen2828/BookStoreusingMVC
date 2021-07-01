using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public CartModel AddToCart(CartModel cart)
        {
            return this.cartRepository.AddToCart(cart);
        }

        public List<GetCartModel> Getcart()
        {
            return this.cartRepository.Getcart();
        }
    }
}
