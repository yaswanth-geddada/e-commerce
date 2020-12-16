using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ECommerce_Application;

namespace ECommerce_Application.Test
{
  [TestFixture]
  class CartTest
  {

    [Test]
    public void Cart_Test()
    {

      Cart cart = new Cart(123, 1000, "OnePlus5", 1, 32999);

      Assert.NotEqual(123, cart.ItemQuantity);
      assert.AreEqual(123, cart.ItemId);
      assert.AreEqual(1000, cart.UserId);
      assert.AreEqual("OnePlus5", cart.ItemName);
      assert.AreEqual(32999, cart.ItemPrice);

      cart.ItemQuantity = 2;

      Assert.NotEqual(1, cart.ItemQuantity);
      Assert.AreEqual(2, cart.ItemQuantity);


    }

  }
}