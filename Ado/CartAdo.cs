using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce_Application
{
  class CartAdo
  {

    private static List<Cart> _cartList = new List<Cart>();

    public void AddToCart()
    {

    }
    public Cart[] GetCartList()
    {
      return _cartList.ToArray();
    }
  }
}
