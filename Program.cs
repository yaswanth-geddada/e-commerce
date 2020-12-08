using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Application
{
    class Program
    {
        int userId = 0;
        private static user[] userData()
        {
            user[] userArray = new user[3];
            userArray[0] = new user("yaswanth", 1234, "customer", 1000, "1234");
            userArray[1] = new user("akshay", 1000, "vendor", 1000, "1000");
            userArray[2] = new user("sai prasanna", 1235, "customer", 1000, "1234");

            return userArray;
        }

        private static products[] productData()
        {
            products[] products = new products[5];
            products[0] = new products("watch", 100, 5);
            products[1] = new products("OnePlus 8", 300, 3);
            products[2] = new products("Laptop", 500, 1);
            products[3] = new products("shirt", 100, 3);
            products[4] = new products("ear phones", 100, 5);

            return products;
        }




        //private static 

        private void menu()
        {
           
            Console.WriteLine("1. login");
            Console.WriteLine("2. view profile");
            Console.WriteLine("3. my orders");

            var choise = Convert.ToInt32(Console.ReadLine());
            menuDetails(choise);

        }

        private void menuDetails(int choise)
        {
            var userId = 1;
            switch (choise)
            {
                case 1: login();
                    break;
                case 2: viewProfile();
                    break;
                case 3: myOrders();
                    break;

            }
            menu();
        }

        private void login()
        {
            var auth = new Auth();
            int flag = 0;

            Console.WriteLine("Enter your UserName");
            var userName =  Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            var user = new user();
            var list = userData();

            foreach(var item in list)
            {
                if(item.UserName == userName && item.password == password)
                {
                    var result = auth.logIn(userName, password);
                    Console.WriteLine(result);
                    userId = item.UserId;
                    flag = 1;
                    //myOrders(item.UserId);
                    break;
                }
                
            }

            if(flag == 0)
            {
                Console.WriteLine("login failed");
            }

        }

        private void viewProfile()
        {
            var userList = userData();
            foreach(var item in userList)
            {
                if(userId == item.UserId)
                {
                    Console.WriteLine("Name : "+item.UserName);
                    Console.WriteLine("Wallet Balance : "+ item.balance);
                    
                }
            }

        }

        private void myOrders()
        {
            var user = new user();
            var userID = user.UserId;
            Console.WriteLine(userId);
        }

        static void Main(string[] args)
        {
            var obj = new Program();
            Console.WriteLine("__________________Welcome to ECommerce Application__________________________");
            obj.menu();
            Program.userData();
           


        }
    }
}
