using System.Collections.Generic;

namespace KneipenFinder.Models
{
    public class User
    {
        private Dictionary<string, User> UserData = new Dictionary<string, User>();
        public string Username { get; set; }
        public string Password { get; set; }
        public string PlaceId { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;

            UserData.Add("Rkal", new User { Password = "passwort", Username = "Rkal", PlaceId = "203100503063200" });
            UserData.Add("JGei", new User { Password = "passwort", Username = "JGei", PlaceId = "1713594378878882" });
            UserData.Add("DEic", new User { Password = "passwort", Username = "DEic", PlaceId = "165809973621368" });
            UserData.Add("VZie", new User { Password = "passwort", Username = "VZie", PlaceId = "203100503063200" });
            UserData.Add("SMei", new User { Password = "passwort", Username = "SMei", PlaceId = "165809973621368" });
            UserData.Add("Admin", new User { Password = "AdminPW123", Username = "Admin", PlaceId = "165809973621368" });
        }

        public User(string username, string passwort, string placeId) : this(username, passwort)
        {
            PlaceId = placeId;

            UserData.Add("Rkal", new User{ Password = "passwort", Username = "Rkal", PlaceId = "203100503063200" });
            UserData.Add("JGei", new User{Password = "passwort", Username = "JGei", PlaceId = "1713594378878882" });
            UserData.Add("DEic", new User { Password = "passwort", Username = "DEic", PlaceId = "165809973621368" });
            UserData.Add("VZie", new User { Password = "passwort", Username = "VZie", PlaceId = "203100503063200" });
            UserData.Add("SMei", new User { Password = "passwort", Username = "SMei", PlaceId = "165809973621368" });
            UserData.Add("Admin", new User { Password = "AdminPW123", Username = "Admin", PlaceId = "165809973621368" });
        }

        private User()
        {

        }

        public bool CheckPassword()
        {
            if (!UserData.ContainsKey(Username))
            {
                return false;
            }

            UserData.TryGetValue(Username, out var user);
            if (!Password.Equals(user?.Password))
            {
                return false;
            }
            else
            {
                PlaceId = user.PlaceId;
            }
            //if (!pw?.Equals(Username))
            //{
            //    return false;
            //}
            //else
            //{
            //    return false;
            //}

            return true;
        }

        public bool CheckUsername()
        {
            if (!UserData.ContainsKey(Username))
            {
                return false;
            }

            return true;
        }
    }
}
