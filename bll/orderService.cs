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
                        //Console.WriteLine(item.quantity + product.Name + product.price);, Status : {3}, item.status
                        Console.WriteLine("ProductId : {3}, Product : {0}, Price : {1}, Quantity : {2}",
                            product.Name, product.price, item.quantity, item.prodId);
                        count = count+1;
                    }
                }  
            }
            return count;
        }
        public string placeOrder(int proId,int userId,int quantity,List<Products> prods,User user)
        {
            string fail = "failed";
            string Status = "Pending";
            _ordersList.Add(new Orders(proId, userId, quantity, Status));
            foreach (var item in prods)
            {
                if(item.prodId == proId)
                {
                    if((item.quantity - quantity) >= 0 && user.balance  >= (item.price * quantity))
                    {
                        item.quantity = item.quantity - quantity;
                        user.balance = user.balance - (item.price * quantity);
                    }
                    else
                    {
                        fail = "quantity is not valid";
                    }
                   
                }
            }
            return fail;
        }

        public void cancleOrder(Orders productObj , User CurrentUser, List<Products> pList)
        {
            _ordersList.Remove(productObj);
            var quant = productObj.quantity;
            var price = 0;
            Products ProductToBeAdded = null;
            var originalQuant = 0;
            foreach (var item in pList)
            {
                if(item.prodId == productObj.prodId)
                {
                    price = item.price;
                    ProductToBeAdded = item;
                    originalQuant = quant + item.quantity;
                    item.quantity = originalQuant;
                }
            }
            CurrentUser.balance = CurrentUser.balance + (price * quant);

            //pList.Add(new Products(
            //    ProductToBeAdded.Name,
            //    ProductToBeAdded.prodId,
            //    ProductToBeAdded.price,
            //    ProductToBeAdded.vendorId,
            //    originalQuant
            //    )); ;
        }
    }
}
