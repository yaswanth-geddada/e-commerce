using ConsoleTables;
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

        public void addProduct(int UserId)
        {
            Random rand = new Random();
            Console.Write("\nEnter ProductName : ");
            string productName = Console.ReadLine();
            int prodId = rand.Next(1000, 9000);
            Console.Write("\nEnter Price of : " + productName + " : ");
            int prodPrice = Convert.ToInt32(Console.ReadLine());
            int vendorId = UserId;
            Console.Write("\nEnter Available Quantity : ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            ProductList.Add(new Products(productName, prodId, prodPrice, vendorId, quantity));
           
        }

        public void viewProducts()
        {
            var table = new ConsoleTable("ProductName", "ProdId", "ProdPrice", "vendorId", "Quantity");
            foreach (var row in _productList)
            {
                table.AddRow(row.Name,row.prodId,row.price,row.vendorId,row.quantity);
            }
            table.Write();
            //table.AddRow()
        }

        public void viewVendorProducts(int vendorId)
        {
            var table = new ConsoleTable("ProductName", "ProdId", "ProdPrice", "vendorId", "Quantity");
            foreach (var row in _productList)
            {
                if (row.vendorId == vendorId)
                {
                    table.AddRow(row.Name, row.prodId, row.price, row.vendorId, row.quantity);

                }
            }
            table.Write();
        }

    }
}
