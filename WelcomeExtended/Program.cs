using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.VIewModel;
using WelcomeExtended.Others;
using Welcome.Model;


namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {
                User user = new User
                (
                    "JohnSmith",
                    "password123",
                    UserRolesEnum.STUDENT,
                    "121221089",
                    "johnsmith@tu-sofia.bg"
                );

                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                view.Display();

                view.DisplayError();
            }
            catch(Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
