using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    // my redis cache allow me to use these listed below interfaces , they just intract with Api
     public interface ICartRepository
    {
        Task<Cart> GetCartAsync(string cartId);
        // this is for debugging GetUser, its internal thing 
        IEnumerable<string> GetUsers();
        // new cart info , we need to update cart
        Task<Cart> UpdateCartAsync(Cart basket);
        // after converting vart to order deleteCart 
        Task<bool> DeleteCartAsync(string id);
    }
}
