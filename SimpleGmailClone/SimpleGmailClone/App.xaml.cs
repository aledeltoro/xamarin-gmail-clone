using SimpleGmailClone.Views;
using Xamarin.Forms;

namespace SimpleGmailClone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEmailsPage()) {
                BarBackgroundColor = Color.FromHex("#EA4335")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
