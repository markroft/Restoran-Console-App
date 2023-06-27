using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDataBase.Modules
{
    public class Users
    {   public int id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string RegistrationTime { get; set; } 
    }
}
