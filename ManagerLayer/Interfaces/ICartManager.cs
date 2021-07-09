using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface ICartManager
    {
        List<GetCartModel> Getcart();
        CartModel AddToCart(CartModel cart, string Email);
    }
}
