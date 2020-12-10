using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce_Application
{
    class orderService
    {
        private static List<Orders> _ordersList = new List<Orders>();

        public List<Orders> OrdersList
        {
            get { return _ordersList; }
            set { _ordersList = value; }
        }

        public orderService()
        {
            _ordersList.Add(new Orders(101, 1234, 1, "Pending"));
            _ordersList.Add(new Orders(102, 1235, 1, "Pending"));
        }

        public int getOrders(List<Products> Products,int custId)
        {
            int count = 0;
            var lis = Products;
            foreach (var product in lis)
            {
                
                foreach (var item in _ordersList)
                {
                    if (product.prodId == item.prodId && custId == item.UserId)
                    {
                        //Console.WriteLine(item.quantity + product.Name + product.price);
                        Console.WriteLine("ProductId : {4}, Product : {0}, Price : {1}, Quantity : {2}, Status : {3}",
                            product.Name, product.price, item.quantity, item.status, item.prodId);
                        count = count+1;
                    }
                }  
            }
            return count;
        }
        public void placeOrder()
        {
            _ordersList.Add(new Orders(102, 1234, 1, "Pending"));
            
        }

        public void cancleOrder(Orders productObj)
        {
            _ordersList.Remove(productObj);
        }
    }
}
