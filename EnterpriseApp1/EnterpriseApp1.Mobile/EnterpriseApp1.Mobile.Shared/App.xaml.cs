using EnterpriseApp1.Mobile.Shared.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EnterpriseApp1.Mobile.Shared
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        // Handle when your app starts
        protected override void OnStart() { }

        // Handle when your app sleeps
        protected override void OnSleep() { }

        // Handle when your app resumes
        protected override void OnResume() { }
    }
}