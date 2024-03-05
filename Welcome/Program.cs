﻿using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.VIewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            User user = new User("Yordan Chulev", "password", UserRolesEnum.ADMIN, "121221089", "chulev3@gmail.com");
            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
            Console.WriteLine("Test");
            Console.ReadKey();
        }
    }
}
