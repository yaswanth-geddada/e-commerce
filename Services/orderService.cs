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
            _ordersList.Add(new Orders(101, 1234, 1));
            _ordersList.Add(new Orders(102, 1235, 1));
        }
        public void placeOrder()
        {
            _ordersList.Add(new Orders(102, 1234, 1));
            
        }
    }
}
