using System;


namespace ECommerce_Application
{
    class Program
    {
        private static User CurrentUser = new User();
        private static userService usr = new userService();
        private static productService produts = new productService();
        private static Authentication Auth = new Authentication();
        private static orderService orders = new orderService();
        private static Design _designHelper = new Design();
        

        private void Menu()
        {

            try
            {

                Console.WriteLine("\nWelcome to ECommerce Application");
                Console.WriteLine("--------------------------------\n");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Exit\n");


                Console.WriteLine("Your Choice");
                int choise = int.Parse(Console.ReadLine());
                MenuDetails(choise);
            }
            catch (Exception)
            {
                Console.WriteLine("_______________");
                Console.WriteLine("Invalid Input");
                Console.WriteLine("_______________");
                Menu();
            }
        }

        private void MenuDetails(int choise)
        {
            try
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
            catch (Exception)
            {
                Console.WriteLine("_______________");
                Console.WriteLine("Invalid Input");
                Console.WriteLine("_______________");
            }
            
        }

        private void Login()
        {
            
            int flag = 0;

            Console.Write("\nEnter your UserName : ");
            var UserName =  Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter password : ");
            
            //hiding the password in console
            var password = usr.hidePassword();
            var UserList = usr.userList;

            foreach(var user in UserList)
            {
                if(user.UserName == UserName && user.password == password)
                {
                    _designHelper.Loader("\nPlease wait Logging In ..", "");
                    var result = Auth.LogIn();
                    Auth.isLogIn();
                    Console.WriteLine(result+ "\n");
                    CurrentUser = user;
                    flag = 1;
                    Console.Clear();
                    LoggedInMenu();
                    break;
                }

            }

            if(flag == 0)
            {
                Console.WriteLine("login failed\n");
                Menu();
            }

                Console.Clear();
                Console.WriteLine("**you are already login**\n");
                Console.Beep();
                Menu();

        }

        private void Register()
        {



            Console.WriteLine("____________________________________________________________________");

            Console.WriteLine(
               "\nPlease select the user Type\nPress 1 for Customer\nPress 2 for Vendor"
               );
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

            Console.Write("Enter UserName : ");
            string UserName = Console.ReadLine();

            Console.Write("\nEnter Password : ");
            string password = Console.ReadLine();



            usr.userRegistration(UserName, UserType, password);


            _designHelper.Loader("\nAccount creation is in process..", "");

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
            try
            {
                if (CurrentUser.role == "Customer")
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
                else if (CurrentUser.role == "Vendor")
                {
                    Console.WriteLine("\nDashboard");
                    Console.WriteLine("-------------\n");
                    Console.WriteLine("0. Clear Screen");
                    Console.WriteLine("1. View Products");
                    Console.WriteLine("2. View profile");
                    Console.WriteLine("3. My Customer Orders");
                    Console.WriteLine("4. Logout");
                    Console.WriteLine("5. LogOut & Exit\n");

                    Console.WriteLine("Your Choice: ");

                    var choice = int.Parse(Console.ReadLine());
                    //if(choice.GetType == "Int")
                    LoggedInMenuDetails(choice);



                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("_______________");
                Console.WriteLine("Invalid Input");
                Console.WriteLine("_______________");
                LoggedInMenu();
            }
           
        }

        private void LoggedInMenuDetails(int choice)
        {
            try
            {
                if (CurrentUser.role == "Customer")
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

                else if (CurrentUser.role == "Vendor")
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
                        //CustomerOrders();
                        case 4:
                            LogOut();
                            break;
                        case 5:
                            Exit();
                            break;
                        default:
                            Console.WriteLine("Please choose an option");
                            LoggedInMenu();
                            break;


                    }

                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("_______________");
                Console.WriteLine("Invalid Input");
                Console.WriteLine("_______________");
                LoggedInMenu();
            }
              

        }

        private void Exit()
        {
            _designHelper.Loader("Logging Out & Exiting ..", "");
            Auth.LogOut();
            Auth = new Authentication();
            CurrentUser = new User();
            Environment.Exit(0);
        }

        private void LogOut()
        {
            _designHelper.Loader("Logging Out .", "");
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

            usr.userProfileTabel(CurrentUser);
            
            
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine("\nSelect An Action");
            Console.WriteLine("----------------");

            if (CurrentUser.role == "Customer" || CurrentUser.role == "customer")
            {
                Console.WriteLine("1. View your order list");

                Console.WriteLine("2. Go back to Menu");

                Console.WriteLine("Your option: ");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    MyOrders();
                }

                else if (op == 2)
                {
                    LoggedInMenu();
                }

                else
                {
                    Console.WriteLine("Please select an option");
                    ViewProfile();
                }

            }
            if(CurrentUser.role == "Vendor" || CurrentUser.role == "vendor")
            {
                VendorProfile();
            }
        }

        private void VendorProfile()
        {
            

            Console.WriteLine("\n1. View your product list");
            Console.WriteLine("2. Add new Product");
            Console.WriteLine("3. View Customer Orders");
            Console.WriteLine("4. Go back to Menu");

            Console.WriteLine("Your option: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                produts.viewVendorProducts(CurrentUser.UserId);
                
                //Console.WriteLine((item.vendorId).ToString(), CurrentUser.UserId);
                VendorProfile();

            }

            else if (op == 2)
            {
                produts.addProduct(CurrentUser.UserId);

                _designHelper.Loader("\nInserting Product Please Wait.....", "\nAdding Product is in process......");
                
                VendorProfile();
            }

            else if (op == 3)
            {
                Console.WriteLine("customers who order vendors products will be shown here");
                VendorProfile();
            }
            else if (op == 4)
            {
                LoggedInMenu();
            }



        }

        private void PlaceOrders()
        {
            if (Auth.isLogIn() == false)
            {
                Console.WriteLine("\nYou Have not logged in. Please Login");
                Login();
            }

            Console.WriteLine("Insert Product ID");
            var pId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the Quantity");
            var quantity = Convert.ToInt32(Console.ReadLine());
            if (Auth.isLogIn() == false)
            {
                Console.WriteLine("\nYou Have not logged in. Please Login");
                Login();
            }

            if(CurrentUser.role != "Vendor" || CurrentUser.role != "vendor")
            {
                Console.Write("Inserting Please Wait...");
                var prods = produts.ProductList;
                User user = CurrentUser;
                var result = orders.placeOrder(pId,CurrentUser.UserId, quantity, prods, user);

                string before = "Inserting Please Wait...";
                string after = "";

                if (result == "quantity is not valid")
                    after = result;
                else
                    after = "Order Inserted Successfully";

                _designHelper.Loader(before, after);
                LoggedInMenu();
            }
            else
            {
                Console.WriteLine("Sorry....you place order !");
            }

        }

        private void MyOrders()
        {
            int op = 0;
            if (Auth.isLogIn() == false)
            {
                Console.WriteLine("\nYou Have not logged in. Please Login");
                Login();
            }
            int count = orders.getOrders(produts.ProductList, CurrentUser.UserId);

            //Console.WriteLine(count) ;
            if(count != 0)
            {
                //Console.WriteLine("____________________________________________________________________");
                Console.WriteLine("\nIf you want to cancle the order press 1");
                Console.WriteLine("\nPress 2 to Go Back");
                op = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("\nNo Orders Found");
                LoggedInMenu();
            }
                
            if(op == 1)
            {
                Console.WriteLine("\nEnter the Product Id");
                int prodId = Convert.ToInt32(Console.ReadLine());
                cancleOrder(prodId);
                
            }
            else
            {
                LoggedInMenu();
            }
            LoggedInMenu();
        }

        private void cancleOrder(int prodId)
        {
            Console.WriteLine("____________________________________________________________________");

            var lis = orders.OrdersList;
            var count = 0;
            foreach (var order in lis)
            {
                
                if(order.prodId == prodId)
                {
                    Orders productObject = order;
                    orders.cancleOrder(productObject, CurrentUser, produts.ProductList);
                    //orders.OrdersList.Remove(order);
                    string before = "Cancling Product Plase Wait...";
                    string after = "Product Cancled";
                    _designHelper.Loader(before, after);
                    count += 1;
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Product with {0} Not found", prodId);
            }
            Console.WriteLine("____________________________________________________________________");

        }

        private void ViewProducts()
        {
            produts.viewProducts(); // Products table
 
            Console.WriteLine("\nSelect an action");
            Console.WriteLine("----------------\n");
            Console.WriteLine("1. Continue Adding To Cart");
            Console.WriteLine("2. Go Back to Menu");

            Console.WriteLine("\nSelect an Option: ");
            int Action = int.Parse(Console.ReadLine());

            switch (Action)
            {
                case 1:
                    //redirecting to place orders
                    PlaceOrders();
                    //Console.WriteLine("\nPlease Select an order ID for action: ");
                    //int ProductId = int.Parse(Console.ReadLine());
                    //ProductActionMenu(ProductId);
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
            Console.WriteLine("____________________________________________________________________");
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
            MyOrders();
        }

        private void AddToCart(int ProductId)
        {
            PlaceOrders();
        }

        static void Main(string[] args)
        {
            var Obj = new Program();

            Obj.Menu();

        }
    }
}
