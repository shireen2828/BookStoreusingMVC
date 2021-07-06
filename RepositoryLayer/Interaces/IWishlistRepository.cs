using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interaces
{
    public interface IWishlistRepository
    {
        WishlistModel AddToWishlist(WishlistModel wishlist);
        List<GetWishlistModel> Getwishlist();
        
    }
}
