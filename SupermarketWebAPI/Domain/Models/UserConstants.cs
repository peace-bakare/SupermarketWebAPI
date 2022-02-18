using System.Collections.Generic;

namespace SupermarketWebAPI.Domain.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "Peace_Admin", EmailAddress = "peace.bakare@live.unilag.edu.ng", GivenName = "Peacethriver",
            Surname = "Bakare", Password = "@P3@ce!~", Role = "Administrator"},
            new UserModel() { Username = "Victor", EmailAddress = "victorbaks@gmail.com", GivenName = "VickyBaks", 
            Surname = "Bakare", Password = "V1ct0r123", Role = "Admin2"}
        };
    }
}
