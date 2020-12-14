using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce_Application
{
  class CartAdo
  {
    private static List<Cart> _cartList = new List<Cart>();

    public static void AddToCart(Cart cart)
    {
      _cartList.Add(cart);
    }
    public static Cart[] GetCartList()
    {
      return _cartList.ToArray();
    }
  }
}
