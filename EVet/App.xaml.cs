using EVet.Views;
namespace EVet
{
    public partial class App : Application
    {
        public static FileResult _mainimgResult;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
