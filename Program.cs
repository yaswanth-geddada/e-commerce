using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce_Application
{
    class Program
    {
        int userId = 0;
        bool isLogin = false;
        private static List<orders> _ordersList = new List<orders>();
        private static List<user> _usersList = new List<user>();
        private static List<products> _productList = new List<products>();

        private void Menu()
        {

            Console.WriteLine("1. login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. view profile");
            Console.WriteLine("4. my orders");
            Console.WriteLine("5. view Products");
            Console.WriteLine("6. View Cart");
            Console.WriteLine("7. Place Orders");
            Console.WriteLine("8. LogOut & Exit\n");


            Console.WriteLine("Your Choice");
            var choise = int.Parse(Console.ReadLine());
            MenuDetails(choise);

        }

        private void MenuDetails(int choise)
        {
            //var userId = 1;
            switch (choise)
            {
                
                case 1:
                    Login();
                    break;
                
                case 2: 
                    Register();
                    break;
                case 3:
                    viewProfile();
                    break;
                case 4:
                    MyOrders();
                    break;
                case 5:
                    viewProducts();
                    break;
                case 6:
                    MyCart();
                    break;
                case 7:
                    PlaceOrders();
                    break;
                case 8:
                    exit();
                    break;
               
                
            }
            Menu();
        }

        private void Login()
        {
            if(this.isLogin == false) { 
            var auth = new Auth();
            int flag = 0;

            Console.WriteLine("\nEnter your UserName");
            var userName =  Console.ReadLine();
            Console.WriteLine("\nEnter password");
            var password = Console.ReadLine();
            var user = new user();
                var list = _usersList;

            foreach(var item in list)
            {
                if(item.UserName == userName && item.password == password)
                {
                    var result = auth.logIn();
                    this.isLogin = auth.islogIn();
                    Console.WriteLine(result+ "\n");
                    userId = item.UserId;
                    flag = 1;
                    //myOrders(item.UserId);
                    break;
                }
                
            }

            if(flag == 0)
            {
                Console.WriteLine("login failed\n");
            }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("**you are already login**\n");
                Console.Beep();
                
            }



        }

        private void Register()
        {
            Console.WriteLine("\nPress 1 for Customer or 2 for Vendor");
            string option = Console.ReadLine();
            string userType;
            if (option == "1")
            {
                userType = "Customer";
            }
            else
            {
                userType = "Vendor";
            }
            Console.WriteLine("\nEnter UserName");
            string userName = Console.ReadLine();
            Console.WriteLine("\nEnter Password\n");
            string password = Console.ReadLine();
            Console.WriteLine("\nEnter UserId");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter Balance");
            int walletMoney = Convert.ToInt32(Console.ReadLine());
            

            _usersList.Add(new user(userName, userId, userType, walletMoney, password));
            Console.WriteLine("\n Account creation is in process...... \n");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n Account has been created Successfully \n userName : {0} , Password : {1}", userName, password);

        }

        private void exit()
        {
            var auth = new Auth();
            auth.logOut();
            System.Environment.Exit(0);

        }

        private void viewProfile()
        {
            var auth = new Auth();
            if (this.isLogin == false)
                {
                Console.WriteLine("please login to access your profile");
                Login();
                }
            var userList = _usersList;
            foreach(var item in userList)
            {
                if(userId == item.UserId)
                {
                    Console.WriteLine("Name : "+item.UserName);
                    Console.WriteLine("Wallet Balance : "+ item.balance+ "\n");                    
                }
            }

            Console.WriteLine("press 1 to view your order list");
            Console.WriteLine("press 2 to Go back");

            int op = Convert.ToInt32(Console.ReadLine());

            if(op == 1)
            {
                MyOrders();
            }
           
            

        }

        private void MyCart()
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }

        private void PlaceOrders()
        {
            _ordersList.Add(new orders(102, 1234, 1));
            Console.WriteLine("Inserting Please Wait");
            Thread.Sleep(2000);
            Console.WriteLine("Order Inserted Successfully");

        }

        private void MyOrders()
        {   
            var res = _ordersList;

            foreach (var item in res)
            {
                if(userId == item.UserId)
                {
                    Console.WriteLine(item.UserId + " " + item.prodId + " " + item.quantity);
                }
            }
        }

        private void viewProducts()
        {
            var productsList = _productList;

            foreach (var item in productsList)
            {
                Console.WriteLine("product name : {0} , price {1}/- , available Quantity {2} \n",
                    item.Name, item.price, item.quantity);
            }
        }

        static void Main(string[] args)
        {
            var obj = new Program();
            Console.WriteLine("________________Welcome to ECommerce Application_________________\n");           
            
            _ordersList.Add(new orders(101, 1234, 1));
            _ordersList.Add(new orders(102, 1235, 1));

            _productList.Add(new products("watch", 101, 100, 5));
            _productList.Add(new products("OnePlus 8", 102, 300, 3));
            _productList.Add(new products("Laptop", 103, 500, 1));
            _productList.Add(new products("shirt", 104, 100, 3));
            _productList.Add(new products("ear phones", 105, 100, 5));

            _usersList.Add(new user("yaswanth", 1234, "customer", 1000, "1234"));
            _usersList.Add(new user("akshay", 1000, "vendor", 1000, "1000"));
            _usersList.Add(new user("sai prasanna", 1235, "customer", 1000, "1234"));

            obj.Menu();

        }
    }
}
