namespace AdminSiste.Services
{
    public class FakeAuthService
    {
        private const string USERNAME = "admin";
        private const string PASSWORD = "123456";

        public bool Login(string username, string password)
        {
            return username == USERNAME && password == PASSWORD;
        }
    }
}