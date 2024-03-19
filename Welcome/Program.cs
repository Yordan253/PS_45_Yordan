using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;


namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            User user = new User("Yordan Chulev", "password", UserRolesEnum.ADMIN);
            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
            Console.WriteLine("Test");
            Console.ReadKey();
        }
    }
}
