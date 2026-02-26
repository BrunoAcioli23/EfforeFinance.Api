using EfforeFinance.App.ViewModels;

namespace EfforeFinance.App.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        // Essa linha diz para a tela: "Pegue seus dados desta ViewModel"
        BindingContext = new DashboardViewModel();
    }
}