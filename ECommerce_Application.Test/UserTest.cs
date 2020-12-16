using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ECommerce_Application;

namespace ECommerce_Application.Test
{
  [TestFixture]
  class OrderTest
  {
    [Test]
    public void orderPlace_test()
    {
      List<Products> _productList = new List<Products>();
      _productList.Add(new Products("watch", 101, 100, 1000, 5));

      User s = new User("Yaswanth", 1234, "Customer", 1000, "1234", "yaswanthgeddada@gmail.com", "test address");

      Orders order = new Orders
      {
        prodId = 101,
        UserId = 1234,
        quantity = 1,
        status = "Pending"
      };

      orderService ord = new orderService();

      string resultSuccess = ord.placeOrder(101, 1234, 1, _productList, s);

      string resultFail = ord.placeOrder(101, 1234, 7, _productList, s);

      Assert.AreEqual("success", resultSuccess);
      Assert.AreNotEqual("success", resultFail);
    }
  }

  [TestFixture]
  class UserTest
  {
    [Test]
    public void Test_for_user_registering()
    {

      User s = new User("Yaswanth", 1234, "Customer", 1000, "1234", "yaswanthgeddada@gmail.com", "test address");


      //User actualvalue = new User("Yaswanth", 1234, "Customer", 1000, "1234");



      Assert.AreEqual(1234, s.UserId);

    }

  }

}

