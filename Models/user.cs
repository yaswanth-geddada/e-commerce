﻿namespace ECommerce_Application
{
    class user
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string role { get; set; }
        public int balance { get; set; }
        public string password { get; set; }

        public user()
        {

        }

        public user(string argUserName, int argUserId, string argrole, int argbalance, string argpassword)
        {
            this.UserName = argUserName;
            this.UserId = argUserId;
            this.role = argrole;
            this.balance = argbalance;
            this.password = argpassword;
        }

 
    }
    }

