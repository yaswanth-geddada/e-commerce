namespace ECommerce_Application
{
    class Authentication
    {
        private bool _isAuth = false;


        public string LogIn()
        {
            this._isAuth = true;
            return "Login Successful";
        }
        public bool isLogIn()
        {
            return _isAuth;
        }
        public void LogOut()
        {
            this._isAuth = false;
        }

        public Authentication()
        {

        }

    }
}
