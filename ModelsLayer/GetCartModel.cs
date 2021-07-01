using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class GetCartModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
