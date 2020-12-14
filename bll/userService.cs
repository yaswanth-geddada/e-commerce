using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleTables;


namespace ECommerce_Application
{
    public class userService
    {
        private static List<User> _UsersList = new List<User>();

        public List<User> userList
        {
            get { return _UsersList; }
        }
        public userService()
        {
            _UsersList.Add(new User("Yaswanth", 1234, "Customer", 1000, "1234"));
            _UsersList.Add(new User("Akshay", 1000, "Vendor", 1000, "1000"));
            _UsersList.Add(new User("Sai Prasanna", 1235, "Customer", 1000, "1234"));
        }




        public void userRegistration(string UserName,string UserType,string password)
        {
            Random rand = new Random();
            int UserId = rand.Next(1000, 2000);
            int walletMoney = 1000;

             _UsersList.Add(new User(UserName, UserId, UserType, walletMoney, password));
        }

        public string hidePassword()
        {
            string pass = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {

                if (info.Key != ConsoleKey.Backspace)
                {
                    pass += info.KeyChar;
                    info = Console.ReadKey(true);

                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(pass))
                    {
                        pass = pass.Substring
                            (0, pass.Length - 1);
                    }
                    info = Console.ReadKey(true);
                }
            }
            for (int i = 0; i < pass.Length; i++)
                Console.Write("*");
            Console.WriteLine("\n");

            return pass;
        }
    
        public void userProfileTabel(User user)
        {
            var table = new ConsoleTable("UserId","User Name","Wallet Balance");
            table.AddRow(user.UserId,user.UserName,user.balance);
            table.Write(Format.Minimal);
        }
    
    }
}
