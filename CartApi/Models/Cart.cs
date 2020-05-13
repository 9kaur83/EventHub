using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class Cart
    {

        // there email address will be buyer ID & the cart will be associated with buyer Id
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; }

        // cartId is BuyerId
        public Cart(string cartId)
        {
            BuyerId = cartId;
            Items = new List<CartItem>();
        }
    }
}
