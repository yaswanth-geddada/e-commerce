using ConsoleTables;
using System;


namespace ECommerce_Application
{
  public class Program
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


        Console.Write("Your Choice: ");
        _designHelper.consoleColorInput();
        int choise = int.Parse(Console.ReadLine());
        _designHelper.consoleColorResetter();
        MenuDetails(choise);
      }
      catch (Exception)
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("\n_______________");
        Console.WriteLine("Invalid Input");
        Console.WriteLine("_______________");
        _designHelper.consoleColorResetter();

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

    public void Login()
    {

      int flag = 0;

      Console.Write("\nEnter your UserName : ");
      _designHelper.consoleColorInput();
      var UserName = Console.ReadLine();
      _designHelper.consoleColorResetter();
      Console.WriteLine();
      Console.Write("Enter password : ");

      //hiding the password in console
      var password = usr.hidePassword();
      var UserList = usr.userList;

      foreach (var user in UserList)
      {
        if (user.UserName == UserName && user.password == password)
        {
          _designHelper.Loader("\nPlease wait Logging In ..", "");
          var result = Auth.LogIn();
          Auth.isLogIn();
          Console.WriteLine(result + "\n");
          CurrentUser = user;
          flag = 1;
          Console.Clear();
          LoggedInMenu();
          break;
        }

      }

      if (flag == 0)
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("login failed\n");
        _designHelper.consoleColorResetter();

        Menu();
      }

      Console.Clear();

      _designHelper.consoleColorFail();
      Console.WriteLine("**you are already login**\n");
      _designHelper.consoleColorResetter();

      Console.Beep();
      Menu();

    }

    private void Register()
    {



      Console.WriteLine("____________________________________________________________________");

      Console.WriteLine(
         "\nPlease select the user Type\nPress 1 for Customer\nPress 2 for Vendor"
         );
      _designHelper.consoleColorInput();
      string option = Console.ReadLine();
      _designHelper.consoleColorResetter();
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

      _designHelper.consoleColorInput();
      string UserName = Console.ReadLine();
      _designHelper.consoleColorResetter();

      Console.Write("\nEnter Password : ");
      _designHelper.consoleColorInput();
      string password = Console.ReadLine();
      _designHelper.consoleColorResetter();



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
          Console.WriteLine("5. Logout");
          Console.WriteLine("6. LogOut & Exit\n");

          Console.WriteLine("Your Choice: ");

          _designHelper.consoleColorInput();
          var choice = int.Parse(Console.ReadLine());
          _designHelper.consoleColorResetter();

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
          _designHelper.consoleColorInput();
          var choice = int.Parse(Console.ReadLine());
          //if(choice.GetType == "Int")
          _designHelper.consoleColorResetter();

          LoggedInMenuDetails(choice);



        }

      }
      catch (Exception)
      {
        Console.Clear();
        _designHelper.consoleColorFail();
        Console.WriteLine("_______________");
        Console.WriteLine("Invalid Input");
        Console.WriteLine("_______________");
        _designHelper.consoleColorResetter();
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
              ViewMyCart();
              break;
            case 5:
              LogOut();
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

        _designHelper.consoleColorInput();
        int op = int.Parse(Console.ReadLine());
        _designHelper.consoleColorResetter();

        if (op == 1)
        {
          MyOrders();
          //MyCart();
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
      if (CurrentUser.role == "Vendor" || CurrentUser.role == "vendor")
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
      _designHelper.consoleColorInput();
      int op = int.Parse(Console.ReadLine());
      _designHelper.consoleColorResetter();
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

    private void PlaceOrders(int ProductId)
    {
      if (Auth.isLogIn() == false)
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("\nYou Have not logged in. Please Login");
        _designHelper.consoleColorResetter();

        Login();
      }

      Console.WriteLine("Insert the Quantity");
      _designHelper.consoleColorInput();
      var quantity = Convert.ToInt32(Console.ReadLine());
      _designHelper.consoleColorResetter();

      if (CurrentUser.role != "Vendor" || CurrentUser.role != "vendor")
      {
        var prods = produts.ProductList;
        User user = CurrentUser;
        var result = orders.placeOrder(ProductId, CurrentUser.UserId, quantity, prods, user);

        string before = "Inserting Please Wait...";
        string after = "";

        if (result == "success")
        {
          after = "Order placed successfully";
        }
        else
        {
          after = "Order cant be placed";
        }

        _designHelper.Loader(before, after);
        LoggedInMenu();
      }
      else
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("Sorry....Can't place order !");
        _designHelper.consoleColorResetter();
      }

    }

    private void MyOrders()
    {
      int op = 0;
      if (Auth.isLogIn() == false)
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("\nYou Have not logged in. Please Login");
        _designHelper.consoleColorResetter();
        Login();
      }
      int count = orders.getOrders(produts.ProductList, CurrentUser.UserId);

      //Console.WriteLine(count) ;
      if (count != 0)
      {
        //Console.WriteLine("____________________________________________________________________");
        Console.WriteLine("\nIf you want to cancle the order press 1");
        Console.WriteLine("\nPress 2 to Go Back");
        _designHelper.consoleColorInput();
        op = Convert.ToInt32(Console.ReadLine());
        _designHelper.consoleColorResetter();
      }
      else
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("\nNo Orders Found");
        _designHelper.consoleColorResetter();

        LoggedInMenu();
      }

      if (op == 1)
      {
        Console.WriteLine("\nEnter the Product Id");
        _designHelper.consoleColorInput();
        int prodId = Convert.ToInt32(Console.ReadLine());
        _designHelper.consoleColorResetter();

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

        if (order.prodId == prodId)
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
        _designHelper.consoleColorFail();
        Console.WriteLine("Product with {0} Not found", prodId);
        _designHelper.consoleColorResetter();
      }

      Console.WriteLine("____________________________________________________________________");

    }

    private void ViewProducts()
    {
      produts.viewProducts(); // Products table
      try
      {
       
        Console.WriteLine("\nSelect an action");
        Console.WriteLine("----------------\n");
        Console.WriteLine("1. Buy Now");
        Console.WriteLine("2. Add To Cart");
        Console.WriteLine("3. Go Back to Menu");

        Console.Write("\nSelect an Option: ");
        _designHelper.consoleColorInput();
        int Action = int.Parse(Console.ReadLine());
        _designHelper.consoleColorResetter();

        switch (Action)
        {
          case 1:
            Console.Write("\nInsert Product ID: ");
            _designHelper.consoleColorInput();
            var ProductId = int.Parse(Console.ReadLine());
            _designHelper.consoleColorResetter();
            PlaceOrders(ProductId);
            break;

          case 2:
            Console.Write("\nInsert Product ID: ");
            _designHelper.consoleColorInput();
            ProductId = int.Parse(Console.ReadLine());
            _designHelper.consoleColorResetter();
            AddToCart(ProductId);
            break;

          case 3:

            if (Auth.isLogIn() == false)
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
      catch (Exception)
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("_______________");
        Console.WriteLine("Invalid Input");
        Console.WriteLine("_______________");
        _designHelper.consoleColorResetter();
        LoggedInMenu();
      }

    }


    private void ViewMyCart()
    {

      Cart[] MyCart = CartService.GetCartList();

      Console.WriteLine("------------------------------------------------------------------");
      Console.WriteLine("|                          My Cart!                              |");
      Console.WriteLine("------------------------------------------------------------------");
      ConsoleTable table = new ConsoleTable("ProductName", "ProdId", "ProdPrice", "Quantity");

      foreach (Cart cart in MyCart)
      {
        if (cart.UserId == CurrentUser.UserId)
        {
          table.AddRow(cart.ItemName, cart.ItemId, cart.ItemPrice, cart.ItemQuantity);
        }
      }

      _designHelper.consoleColorSuccess();
      table.Write();
      _designHelper.consoleColorResetter();

      Console.WriteLine("\nSelect an option");
      Console.WriteLine("----------------");
      Console.WriteLine("1. Checkout.");
      Console.WriteLine("2. Continue Shopping.");
      Console.WriteLine("3. Go back to Menu.");

      Console.Write("\nYour option: ");
      _designHelper.consoleColorInput();
      var option = int.Parse(Console.ReadLine());
      _designHelper.consoleColorResetter();

      switch (option)
      {
        case 1:
          Checkout();
          break;
        case 2:
          ViewProducts();
          break;
        case 3:
          LoggedInMenu();
          break;
        default:
          Console.WriteLine("Please choose an option");
          ViewMyCart();
          break;

      }


    }

    private void Checkout()
    {

      Cart[] MyCart = CartService.GetCartList();

      if (CurrentUser.role != "Vendor" || CurrentUser.role != "vendor")
      {
        var prods = produts.ProductList;
        User user = CurrentUser;

        foreach (var cart in MyCart)
        {
          if (cart.UserId == CurrentUser.UserId)
          {
            orders.placeOrder(cart.ItemId, CurrentUser.UserId, cart.ItemQuantity, prods, user);
          }
        }
        string before = "Inserting Please Wait...";
        string after = "";

        //if (result == "success")
        //{
        //  after = "Order placed successfully";
        //}
        //else
        //{
        //  after = "Order cant be placed";
        //}

        _designHelper.Loader(before, after);
        LoggedInMenu();
      }
      else
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("Sorry....Can't place order !");
        _designHelper.consoleColorResetter();
      }

    }

    private void AddToCart(int ProductId)
    {
      Console.Write("Insert the Quantity: ");
      _designHelper.consoleColorInput();
      var quantity = Convert.ToInt32(Console.ReadLine());
      _designHelper.consoleColorResetter();

      if (CurrentUser.role != "Vendor" || CurrentUser.role != "vendor")
      {
        var prods = produts.ProductList;
        foreach (var prod in prods)
        {
          if (ProductId == prod.prodId)
            CartService.AddToCart(new Cart(ProductId, CurrentUser.UserId, prod.Name, quantity, prod.price));
        }

                _designHelper.consoleColorSuccess();
                Console.WriteLine("Added to Cart...");
                _designHelper.consoleColorResetter();
                LoggedInMenu();
      }
      else
      {
        _designHelper.consoleColorFail();
        Console.WriteLine("Sorry.... Vender cannot place order.");
        _designHelper.consoleColorResetter();
      }
    }

    static void Main(string[] args)
    {
      var Obj = new Program();


      Obj.Menu();

    }
  }
}
