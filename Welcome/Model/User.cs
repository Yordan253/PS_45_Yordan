using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    internal class User
    {
        private string names;
        private string password;
        private UserRolesEnum role;
       

        public User(String _names, String _password, UserRolesEnum _role)
        {
            this.names = _names;
            this.password = _password;
            this.role = _role;
        }

        public string Names { 
            get { return names; } 
            set { names = value; } 
        }
        public string Password {
            get { return password; }
            set{ password = value; }
        }
        public UserRolesEnum Role {
            get { return role; }
            set {role = value; } 
        }
    }
}
