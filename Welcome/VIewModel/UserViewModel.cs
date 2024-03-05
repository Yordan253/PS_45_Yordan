using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace Welcome.VIewModel
{
    public class UserViewModel
    {
        public User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }

        public String Names
        {
            get { return _user.Names; }
            set { _user.Names = value;}
        }

        public String Password
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }

        public Others.UserRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }
        public String FacultyNumber
        {
            get { return _user.FacultyNumber; }
            set { _user.FacultyNumber = value; }
        }
        public String Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }
    }
}
