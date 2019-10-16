using System.Collections.Generic;

namespace BethanysPieShopMobile.API.Model
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new List<ShoppingCartItem>();
        }

        public List<ShoppingCartItem> CartItems
        {
            get;
            set;
        }
    }
}
