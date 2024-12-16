using EVet.Models;
using EVet.Views;
namespace EVet
{
    public partial class App : Application
    {
        public static FileResult _mainimgResult;
        public static string UserkeyUser, fullNameUser, key;
        public App()
        {
            InitializeComponent();


            //MainPage = new PageHome();

            MainPage = new NavigationPage(new PageFront());

        }
    }
}
