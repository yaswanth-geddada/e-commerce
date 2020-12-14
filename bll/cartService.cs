using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections;


namespace ECommerce_Application
{

    class cartService
    {
        string filePath = @"/cart.txt";

        public cartService()
        {
            //Console.WriteLine(string.Join("", readRecord("102", filePath, 0)));
            
        }

        public string AddtoCart(int proId, int userId,int quantity, List<Products> prods, User user, List<Orders> orderList)
        {

            string message = "failed";
            string Status = "Pending";

            foreach (var item in prods)
            {
                if (item.prodId == proId)
                {
                    if (((item.quantity >= quantity) && user.balance >= (item.price * quantity)))
                    {
                        orderList.Add(new Orders(proId, userId, quantity, Status));
                        item.quantity = item.quantity - quantity;
                        user.balance = user.balance - (item.price * quantity);

                        try
                        {
                            using (StreamWriter file = new StreamWriter(filePath, true))
                            {

                                file.WriteLine(proId+","+ userId+","+quantity + "," + Status);
                                message = "success";
                            }
                            return message;
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException("something went wrong : ", ex.InnerException);
                        }
                    }
                }
            }
            return message;
        }



        public  List<Orders> getCart(string searchTerm, int positionOfSearchTerm)
        {
            List<Orders> recordNotFound = new List<Orders>();
            //recordNotFound.Add("Record not found");//string[] rec = { };
            List<Orders> rec = new List<Orders>();
           

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (recordMatches(searchTerm, fields, positionOfSearchTerm))
                    {
                        //Console.WriteLine(fields[0] + " " + fields[1]);
                        rec.Add(new Orders(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[1]) , Convert.ToInt32(fields[2]), "Pending"));
                    }

                }
                return rec;
            }
            catch (Exception ex)
            {
                Console.WriteLine("this pro");
                throw new ApplicationException("not found", ex);
            }
        }

        public static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }


        public void cartTable(List<Orders> cartList, List<Products> productsList,int custId)
        {
            var table = new ConsoleTable("ProductName", "ProdId", "ProdPrice", "vendorId", "Quantity");
            foreach (var product in productsList)
            {

                foreach (var item in cartList)
                {
                    if (product.prodId == item.prodId && custId == item.UserId)
                    {
                        table.AddRow(product.Name, item.prodId, product.price, product.vendorId, item.quantity);
                    }
                }
            }
        
        table.Write(Format.Alternative);

        }
    }
}
