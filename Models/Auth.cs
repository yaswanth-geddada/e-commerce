namespace ECommerce_Application
{
    class Auth
    {
        private bool _isAuth=false;

        
        public string logIn()
        {
            this._isAuth = true;
            return "login successful";
        }
        public bool islogIn()
        {
            return _isAuth;
        }
        public void logOut()
        {
            this._isAuth = false;
        }

    }
}
