namespace ECommerce_Application
{
    public class User
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string role { get; set; }
        public int balance { get; set; }
        public string password { get; set; }

        public User()
        {

        }

        public User(string argUserName, int argUserId, string argrole, int argbalance, string argpassword)
        {
            this.UserName = argUserName;
            this.UserId = argUserId;
            this.role = argrole;
            this.balance = argbalance;
            this.password = argpassword;
        }

        public override string ToString()
        {
            return (this.UserName + ", " + this.UserId + ", " + this.role + ", " + this.balance + ", " + this.password);
        }

    }
    }

