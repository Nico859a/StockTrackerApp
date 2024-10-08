namespace StockTrackerApp
{
    public class AuthService
    {
        private List<User> users = new List<User>();
        public User? CurrentUser { get; private set; } // Make CurrentUser nullable

        public void Register(string username, string password)
        {
            // Store user details in the list
            users.Add(new User { Username = username, Password = password });
        }

        public bool Login(string username, string password)
        {
            // Check if user exists
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null; // No issue with null assignment now
        }

        public bool IsAuthenticated() => CurrentUser != null;

        public class User // Make User class public
        {
            public string Username { get; set; } = string.Empty; // Initialize properties
            public string Password { get; set; } = string.Empty; // Initialize properties
        }
    }
}
