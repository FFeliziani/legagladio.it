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
            LegaGladioDSTableAdapters.usersTableAdapter uta = null;

            uta = new LegaGladioDSTableAdapters.usersTableAdapter();
            Int32 userCount = Convert.ToInt32(uta.checkUsername(username));
            if (userCount > 1)
            {
                throw new Exception("Wrong number of users returned... SOMETHING IS WRONG IN THE DB");
            }

            return userCount == 1;
        }

        public static Boolean checkPassword(String username, String password)
        {
            LegaGladioDSTableAdapters.usersTableAdapter uta = null;
            Int32 userCount = 0;

            uta = new LegaGladioDSTableAdapters.usersTableAdapter();
            userCount = Convert.ToInt32(uta.checkPassword(username, password));
            if (userCount > 1)
            {
                throw new Exception("WRONG NUMBER OF USERS RETURNED!!!!! SOMETHING IS VERY VERY WRONG IN THE DB");
            }
            return userCount == 1;
        }

        public static void insertToken(String username, String token)
        {
            LegaGladioDSTableAdapters.usersTableAdapter uta = null;

            uta = new LegaGladioDSTableAdapters.usersTableAdapter();

            uta.insertToken(token, username);

        }

        public static Boolean checkLogged(String token)
        {
            LegaGladioDSTableAdapters.usersTableAdapter uta = null;
            Int32 userCount = 0;

            uta = new LegaGladioDSTableAdapters.usersTableAdapter();

            userCount = Convert.ToInt32(uta.checkLogged(token));

            if (userCount > 1)
            {
                throw new Exception("WRONG USER RETURNED WHEN CHECKING IF LOGGED............... WTF");
            }

            return userCount == 1;
        }

        public static void logout(String token)
        {
            LegaGladioDSTableAdapters.usersTableAdapter uta = null;

            uta = new LegaGladioDSTableAdapters.usersTableAdapter();

            uta.logout(token);
        }
    }
}
