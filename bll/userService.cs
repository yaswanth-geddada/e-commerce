using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce_Application
{
    class userService
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
    }
}
