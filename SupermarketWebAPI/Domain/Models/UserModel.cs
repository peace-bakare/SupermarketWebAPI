using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketWebAPI.Domain.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string DateOfJoining { get; set; }
    }
}
