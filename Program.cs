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
        int UserId = 0;
        bool isLogin = false;
        private static List<Orders> _ordersList = new List<Orders>();
        private static List<User> _UsersList = new List<User>();
        private static List<Products> _productList = new List<Products>();

        private void Menu()
        {

            Console.WriteLine("Welcome to ECommerce Application");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Exit\n");


            Console.WriteLine("Your Choice");
            var choise = int.Parse(Console.ReadLine());
            MenuDetails(choise);

        }

        private void MenuDetails(int choise)
        {
            //var UserId = 1;
            switch (choise)
            {
                
                case 1:
                    Login();
                    break;
                case 2: 
                    Register();
                    break;
                case 3:
                    ViewProducts();
                    break;
                case 4:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose an option");
                    Menu();
                    break;

            }
        }

        private void Login()
        {
            if(this.isLogin == false) { 
            var auth = new Auth();
            int flag = 0;

            Console.WriteLine("\nEnter your UserName");
            var UserName =  Console.ReadLine();
            Console.WriteLine("\nEnter password");
            var password = Console.ReadLine();
            var User = new User();
                var list = _UsersList;

            foreach(var item in list)
            {
                if(item.UserName == UserName && item.password == password)
                {
                    var result = auth.logIn();
                    this.isLogin = auth.islogIn();
                    Console.WriteLine(result+ "\n");
                    UserId = item.UserId;
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
            string UserType;
            if (option == "1")
            {
                UserType = "Customer";
            }
            else
            {
                UserType = "Vendor";
            }
            Console.WriteLine("\nEnter UserName");
            string UserName = Console.ReadLine();
            Console.WriteLine("\nEnter Password\n");
            string password = Console.ReadLine();
            Console.WriteLine("\nEnter UserId");
            int UserId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter Balance");
            int walletMoney = Convert.ToInt32(Console.ReadLine());
            

            _UsersList.Add(new User(UserName, UserId, UserType, walletMoney, password));
            Console.WriteLine("\n Account creation is in process...... \n");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n Account has been created Successfully \n UserName : {0} , Password : {1}", UserName, password);

        }



        private void LoggedInMenu()
        {
            Console.WriteLine("\nDashboard");
            Console.WriteLine("-------------\n");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. View profile");
            Console.WriteLine("3. My Orders");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Place Orders");
            Console.WriteLine("6. Log Out & Exit\n");

            Console.WriteLine("Your Choice: ");
            var choice = int.Parse(Console.ReadLine());
            LoggedInMenuDetails(choice);
        }

        private void LoggedInMenuDetails(int choice)
        {
            switch (choice)
            {

                case 1:
                    ViewProducts();
                    break;
                case 2:
                    ViewProfile();
                    break;
                case 3:
                    MyOrders();
                    break;                
                case 4:
                    MyCart();
                    break;
                case 5:
                    PlaceOrders();
                    break;
                case 6:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Please choose an option");
                    LoggedInMenu();
                    break;

            }

        }


        private void Exit()
        {
            var auth = new Auth();
            auth.logOut();
            System.Environment.Exit(0);

        }

        private void ViewProfile()
        {
            var auth = new Auth();
            if (this.isLogin == false)
                {
                Console.WriteLine("please login to access your profile");
                Login();
                }
            var UserList = _UsersList;
            foreach(var item in UserList)
            {
                if(UserId == item.UserId)
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

        private void PlaceOrders()
        {
            _ordersList.Add(new Orders(102, 1234, 1));
            Console.WriteLine("Inserting Please Wait");
            Thread.Sleep(2000);
            Console.WriteLine("Order Inserted Successfully");

        }

        private void MyOrders()
        {   
            var res = _ordersList;

            foreach (var item in res)
            {
                if(UserId == item.UserId)
                {
                    Console.WriteLine(item.UserId + " " + item.prodId + " " + item.quantity);
                }
            }
        }

        private void ViewProducts()
        {
            var productsList = _productList;

            foreach (var item in productsList)
            {
                Console.WriteLine("product name : {0}\nprice {1}/- \navailable Quantity {2} \n",
                    item.Name, item.price, item.quantity);
            }

            Console.WriteLine("\nSelect an action");
            Console.WriteLine("----------------\n");
            Console.WriteLine("1. Continue Adding To Cart");
            Console.WriteLine("2. Go Back to Menu");

            Console.WriteLine("\nSelect an Option: ");
            int Action = int.Parse(Console.ReadLine());

            switch (Action)
            {
                case 1:
                    Console.WriteLine("\nPlease Select an order ID for action: ");
                    int OrderId = int.Parse(Console.ReadLine());
                    ProductActionMenu(OrderId);
                    break;

                case 2:
                    var Auth = new Auth();

                    if(Auth.islogIn() == false)  
                        Menu();

                    else
                        LoggedInMenu();
                    
                    break;

                default:
                    Console.WriteLine("\nPlease Select an Option.");
                    ViewProducts();
                    break;
            }
        }

        private void ProductActionMenu(int OrderId)
        {
            Console.WriteLine("\nSelect an action");
            Console.WriteLine("----------------\n");
            Console.WriteLine("1. Add to Cart");
            Console.WriteLine("2. Go Back to Menu");

            Console.WriteLine("\nYour option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    break;

                case 2:
                    var Auth = new Auth();

                    if (Auth.islogIn() == false)
                        Menu();

                    else
                        LoggedInMenu();

                    break;

                default:
                    Console.WriteLine("\nPlease Select an Option");
                    ProductActionMenu(OrderId);
                    break;

            }
        }

        private void MyCart()
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }

        static void Main(string[] args)
        {
            var obj = new Program();         
            
            _ordersList.Add(new Orders(101, 1234, 1));
            _ordersList.Add(new Orders(102, 1235, 1));

            _productList.Add(new Products("watch", 101, 100, 5));
            _productList.Add(new Products("OnePlus 8", 102, 300, 3));
            _productList.Add(new Products("Laptop", 103, 500, 1));
            _productList.Add(new Products("shirt", 104, 100, 3));
            _productList.Add(new Products("ear phones", 105, 100, 5));

            _UsersList.Add(new User("Yaswanth", 1234, "customer", 1000, "1234"));
            _UsersList.Add(new User("Akshay", 1000, "vendor", 1000, "1000"));
            _UsersList.Add(new User("Sai Prasanna", 1235, "customer", 1000, "1234"));

            obj.Menu();


        }
    }
}
