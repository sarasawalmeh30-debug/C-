using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studant_manegment_system.Models 
{
    public class User
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }

    }
}