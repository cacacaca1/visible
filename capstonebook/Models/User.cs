using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capstonebook.Models
{
    public class User
    {
        public int number { get; set; }
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string OX { get; set; }
        public int delayday { get; set; }
    }
}