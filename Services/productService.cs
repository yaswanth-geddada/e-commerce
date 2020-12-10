using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce_Application
{
    class productService
    {
        private static List<Products> _productList = new List<Products>();

        public List<Products> ProductList
        {
            get { return _productList; }
        }

        public productService()
        {
            //itemName,prodID,price,quantity,vendorId
            _productList.Add(new Products("watch", 101, 100, 1000, 5));
            _productList.Add(new Products("OnePlus 8", 102, 300, 1000, 3));
            _productList.Add(new Products("Laptop", 103, 500, 1000, 1));
            _productList.Add(new Products("shirt", 104, 100, 1000, 3));
            _productList.Add(new Products("ear phones", 105, 100, 1001, 5));

        }


    }
}
