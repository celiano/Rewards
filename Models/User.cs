using RewardsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RewardsWebApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
    }
}