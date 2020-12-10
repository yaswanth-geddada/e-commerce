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
        private static User CurrentUser = new User();
        private static Authentication Auth = new Authentication();
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
                case 0:
                    Console.Clear();
                    Console.WriteLine("**cleared**\n");
                    Console.Beep();
                    Menu();
                    break;


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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose an option");
                    Menu();
                    break;

            }
        }

        private void Login()
        {

            int flag = 0;

            Console.WriteLine("\nEnter your UserName");
            var UserName =  Console.ReadLine();
            Console.WriteLine("\nEnter password");
            var password = Console.ReadLine();
            var User = new User();
                var UserList = _UsersList;

            foreach(var user in UserList)
            {
                if(user.UserName == UserName && user.password == password)
                {
                    var result = Auth.LogIn();
                    Auth.isLogIn();
                    Console.WriteLine(result+ "\n");
                    CurrentUser = user;
                    flag = 1;
                    Console.WriteLine("Please wait Logging In ......");
                    Thread.Sleep(2000);
                    Console.Clear();
                    LoggedInMenu();
                    break;
                }

            }

            if(flag == 0)
            {
                Console.WriteLine("login failed\n");
            }

                Console.Clear();
                Console.WriteLine("**you are already login**\n");
                Console.Beep();

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

            int walletMoney = 5000;

            _UsersList.Add(new User(UserName, UserId, UserType, walletMoney, password));
            Console.WriteLine("\n Account creation is in process...... \n");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(
                "\n Account has been created Successfully \n UserName : {0} , Password : {1}",
                UserName, password
                );
            Console.WriteLine("\nPlease Login");
            Login();

        }



        private void LoggedInMenu()
        {
            Console.WriteLine("\nDashboard");
            Console.WriteLine("-------------\n");
            Console.WriteLine("0. Clear Screen");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. View profile");
            Console.WriteLine("3. My Orders");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Place Orders");
            Console.WriteLine("6. Logout");
            Console.WriteLine("7. LogOut & Exit\n");

            Console.WriteLine("Your Choice: ");
            var choice = int.Parse(Console.ReadLine());
            LoggedInMenuDetails(choice);
        }

        private void LoggedInMenuDetails(int choice)
        {
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("**cleared**\n");
                    Console.Beep();
                    LoggedInMenu();
                    break;

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
                    LogOut();
                    break;
                case 7:
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
            Auth.LogOut();
            Auth = new Authentication();
            CurrentUser = new User();
            Environment.Exit(0);
        }

        private void LogOut()
        {
            Auth.LogOut();
            Auth = new Authentication();
            CurrentUser = new User();
            Menu();
        }

        private void ViewProfile()
        {
            if (Auth.isLogIn() == false)
            {
                Console.WriteLine("\nYou Have not logged in. Please Login");
                Login();
            }


            Console.WriteLine("\nName : "+CurrentUser.UserName);
            Console.WriteLine("Wallet Balance : "+ CurrentUser.balance+ "\n");
            Console.WriteLine("\nSelect An Action");
            Console.WriteLine("----------------");
            Console.WriteLine("1. View your order list");
            Console.WriteLine("2. Go back to Menu");

            Console.WriteLine("Your option: ");
            int op = int.Parse(Console.ReadLine());

            if(op == 1)
            {
                MyOrders();
            }

            else if(op == 2)
            {
                LoggedInMenu();
            }

            else
            {
                Console.WriteLine("Please select an option");
                ViewProfile();
            }



        }

        private void PlaceOrders()
        {

            if (Auth.isLogIn() == false)
            {
                Console.WriteLine("\nYou Have not logged in. Please Login");
                Login();
            }

            _ordersList.Add(new Orders(102, 1234, 1));
            Console.WriteLine("Inserting Please Wait");
            Thread.Sleep(2000);
            Console.WriteLine("Order Inserted Successfully");
            LoggedInMenu();

        }

        private void MyOrders()
        {
            if (Auth.isLogIn() == false)
            {
                Console.WriteLine("\nYou Have not logged in. Please Login");
                Login();
            }

            var MyOrdersList = _ordersList;

            foreach (var MyOrder in MyOrdersList)
            {
                if(CurrentUser.UserId == MyOrder.UserId)
                {
                    Console.WriteLine(MyOrder.UserId + " " + MyOrder.prodId + " " + MyOrder.quantity);
                }
            }

            LoggedInMenu();
        }

        private void ViewProducts()
        {
            var ProductsList = _productList;

            foreach (var product in ProductsList)
            {
                Console.WriteLine("product name : {0}\nprice {1}/- \navailable Quantity {2} \n",
                    product.Name, product.price, product.quantity);
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
                    int ProductId = int.Parse(Console.ReadLine());
                    ProductActionMenu(ProductId);
                    break;

                case 2:

                    if(Auth.isLogIn() == false)
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

        private void ProductActionMenu(int ProductId)
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
                    AddToCart(ProductId);
                    break;

                case 2:

                    if (Auth.isLogIn() == false)
                        Menu();

                    else
                        LoggedInMenu();

                    break;

                default:
                    Console.WriteLine("\nPlease Select an Option");
                    ProductActionMenu(ProductId);
                    break;

            }
        }

        private void MyCart()
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }

        private void AddToCart(int ProductId)
        {
            Console.WriteLine("\n WORK IN PROGRESS \n");
        }

        static void Main(string[] args)
        {
            var Obj = new Program();

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

            Obj.Menu();


        }
    }
}
