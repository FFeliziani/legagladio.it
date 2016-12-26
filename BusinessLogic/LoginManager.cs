using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class LoginManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static String Login(String username, String password)
        {
            String token = "";
            try
            {
                // Check if user exists
                Boolean usernameExists = DataAccessLayer.LoginManager.existsUser(username);
                if (!usernameExists)
                {
                    throw new AccessViolationException("Username does not exist");
                }
                // Check if password matches
                Boolean passwordMatch = DataAccessLayer.LoginManager.checkPassword(username, password);
                if (!passwordMatch)
                {
                    throw new AccessViolationException("Username and Password do not match");
                }
                // Generate Token
                Guid guid = Guid.NewGuid();
                token = guid.ToString();
                DataAccessLayer.LoginManager.insertToken(username, token);
            }
            catch (Exception ex)
            {
                logger.Error("Error while trying to login");
                throw ex;
            }
            return token;
        }

        public static Boolean checkLogged(String token)
        {
            return DataAccessLayer.LoginManager.checkLogged(token);
        }

        public static void logout(String token)
        {
            DataAccessLayer.LoginManager.logout(token);
        }
    }
}
