using System;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class LoginManager
    {
        public static Boolean ExistsUser(String username)
        {
            var uta = new usersTableAdapter();
            var userCount = Convert.ToInt32(uta.checkUsername(username));
            if (userCount > 1) throw new Exception("Wrong number of users returned... SOMETHING IS WRONG IN THE DB");
            return userCount == 1;
        }

        public static Boolean CheckPassword(String username, String password)
        {
            var uta = new usersTableAdapter();
            var userCount = Convert.ToInt32(uta.checkPassword(username, password));
            if (userCount > 1)
                throw new Exception("WRONG NUMBER OF USERS RETURNED!!!!! SOMETHING IS VERY VERY WRONG IN THE DB");
            return userCount == 1;
        }

        public static void InsertToken(String username, String token)
        {
            var uta = new usersTableAdapter();

            uta.insertToken(token, username);
        }

        public static Boolean CheckLogged(String token)
        {
            var uta = new usersTableAdapter();

            var userCount = Convert.ToInt32(uta.checkLogged(token));

            if (userCount > 1) throw new Exception("WRONG USER RETURNED WHEN CHECKING IF LOGGED............... WTF");
            return userCount == 1;
        }

        public static void Logout(String token)
        {
            var uta = new usersTableAdapter();

            uta.logout(token);
        }
    }
}
