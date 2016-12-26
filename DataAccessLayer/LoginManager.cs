using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class LoginManager
    {
        public static Boolean existsUser(String username)
        {
            LoginTableAdapters.usersTableAdapter uta = null;
            Int32 userCount = 0;

            uta = new LoginTableAdapters.usersTableAdapter();
            userCount = (int)uta.checkUsername(username);
            if (userCount > 1)
            {
                throw new Exception("Wrong number of users returned... SOMETHING IS WRONG IN THE DB");
            }

            return userCount == 1;
        }

        public static Boolean checkPassword(String username, String password)
        {
            LoginTableAdapters.usersTableAdapter uta = null;
            Int32 userCount = 0;

            uta = new LoginTableAdapters.usersTableAdapter();
            userCount = (int)uta.checkPassword(username, password);
            if (userCount > 1)
            {
                throw new Exception("WRONG NUMBER OF USERS RETURNED!!!!! SOMETHING IS VERY VERY WRONG IN THE DB");
            }
            return userCount == 1;
        }

        public static void insertToken(String username, String token)
        {
            LoginTableAdapters.usersTableAdapter uta = null;

            uta = new LoginTableAdapters.usersTableAdapter();

            uta.insertToken(token, username);

        }

        public static Boolean checkLogged(String token)
        {
            LoginTableAdapters.usersTableAdapter uta = null;
            Int32 userCount = 0;

            uta = new LoginTableAdapters.usersTableAdapter();

            userCount = (int)uta.checkLogged(token);

            if (userCount > 1)
            {
                throw new Exception("WRONG USER RETURNED WHEN CHECKING IF LOGGED............... WTF");
            }

            return userCount == 1;
        }

        public static void logout(String token)
        {
            LoginTableAdapters.usersTableAdapter uta = null;

            uta = new LoginTableAdapters.usersTableAdapter();

            uta.logout(token);
        }
    }
}
