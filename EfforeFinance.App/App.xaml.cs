using EfforeFinance.App.Views;

namespace EfforeFinance.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DashboardPage());
        }
    }
}