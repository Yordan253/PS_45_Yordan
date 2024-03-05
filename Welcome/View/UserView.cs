using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Welcome.VIewModel;

namespace Welcome.View
{
    internal class UserView
    {
        private UserViewModel _userViewModel;

        

        public UserView(UserViewModel userViewModel)
        {
            _userViewModel = userViewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User: "+ _userViewModel.Names);
            Console.WriteLine("Role: "+ _userViewModel.Role);
            Console.WriteLine("Faculty number: "+ _userViewModel.FacultyNumber);
            Console.WriteLine("Email: "+ _userViewModel.Email);
        }

        
    }
}
