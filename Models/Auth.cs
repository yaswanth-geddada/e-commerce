namespace ECommerce_Application
{
    class Auth
    {
        private bool _isAuth = false;

        
        public string logIn(string userName, string password)
        {
            this._isAuth = true;
            return "login successful";
        }

        public void logOut()
        {
            this._isAuth = false;
        }

    }
}
