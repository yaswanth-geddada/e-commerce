namespace ECommerce_Application
{
    class Auth
    {
        private bool _isAuth;

        
        public string logIn(string userName, string password)
        {
            _isAuth = true;
            return "login successful";
        }

        public void logOut()
        {
            this._isAuth = false;
        }

    }
}
