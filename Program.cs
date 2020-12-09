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

        private void Menu()
        {

            Console.WriteLine("________________Welcome to ECommerce Application_________________\n");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit\n");


            Console.WriteLine("Your Choice");
            var choise = int.Parse(Console.ReadLine());
            MenuDetails(choise);

        }

        private void MenuDetails(int choise)
        {
            var userId = 1;
            switch (choise)
            {
                case 1: Login();
                    break;
                case 2: Register();
                    break;
                case 3: 
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please Select one of the option");
                    Menu();
                    break;
            }
        }

        private void Login()
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

            LoggedInMenu();

        }

        private void Register()
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }


        private void LoggedInMenu()
        {
            Console.WriteLine("\nSelect An Option");
            Console.WriteLine("----------------\n");
            Console.WriteLine("1. View profile");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Place Orders");
            Console.WriteLine("4. My Orders\n");

            Console.WriteLine("Your Choice");
            var choice = int.Parse(Console.ReadLine());
            LoggedInMenuDetails(choice);
        }

        private void LoggedInMenuDetails(int choice)
        {
            var userId = 1;
            switch (choice)
            {
                case 1:
                    ViewProfile();
                    break;
                case 2:
                    MyCart();
                    break;
                case 3:
                    PlaceOrders();
                    break;
                case 4:
                    MyOrders();
                    break;

                default:
                    Console.WriteLine("Please Select one of the option");
                    LoggedInMenu();
                    break;


            }
        }

        private void ViewProfile()
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

        private void MyCart()
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }

        private void PlaceOrders()
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }

        private void MyOrders()
        {
            var user = new user();
            var userID = user.UserId;
            Console.WriteLine(userId);
        }

        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Menu();
            Program.userData();
           


        }
    }
}
