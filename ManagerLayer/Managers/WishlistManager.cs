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
    public class WishlistManager : IWishlistManager
    {
        private readonly IWishlistRepository wishlistRepository;
        public WishlistManager (IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }

        public List<GetWishlistModel> Getwishlist()
        {
            return this.wishlistRepository.Getwishlist();
        }

        public WishlistModel AddToWishlist(WishlistModel wishlist)
        {
            return this.wishlistRepository.AddToWishlist(wishlist);
        }
    }
    
}
