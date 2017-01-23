using System;
using NLog;

namespace BusinessLogic
{
    public static class LoginManager
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static String Login(String username, String password)
        {
            String token;
            try
            {
                // Check if user exists
                var usernameExists = DataAccessLayer.LoginManager.ExistsUser(username);
                if (!usernameExists)
                {
                    throw new AccessViolationException("Username does not exist");
                }
                // Check if password matches
                var passwordMatch = DataAccessLayer.LoginManager.CheckPassword(username, password);
                if (!passwordMatch)
                {
                    throw new AccessViolationException("Username and Password do not match");
                }
                // Generate Token
                var guid = Guid.NewGuid();
                token = guid.ToString();
                DataAccessLayer.LoginManager.InsertToken(username, token);
            }
            catch (Exception)
            {
                Logger.Error("Error while trying to login - Username: [" + username + "]");
                throw;
            }
            return token;
        }

        public static Boolean CheckLogged(String token)
        {
            return DataAccessLayer.LoginManager.CheckLogged(token);
        }

        public static void Logout(String token)
        {
            DataAccessLayer.LoginManager.Logout(token);
        }
    }
}
