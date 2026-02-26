using CommunityToolkit.Mvvm.ComponentModel;
using EfforeFinance.App.Models;
using EfforeFinance.App.Services;
using System.Collections.ObjectModel;

namespace EfforeFinance.App.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        [ObservableProperty]
        private decimal _saldoAtual;

        [ObservableProperty]
        private ObservableCollection<ResumoDespesa> _despesas;

        public DashboardViewModel()
        {
            _apiService = new ApiService();
            Despesas = new ObservableCollection<ResumoDespesa>();

            _ = CarregarDashboardAsync();
        }

        private async Task CarregarDashboardAsync()
        {
            SaldoAtual = await _apiService.ObterSaldoContaAsync(1);

            var lista = await _apiService.ObterResumoDespesasAsync(1, 2, 2026);

            Despesas.Clear();
            foreach (var item in lista)
            {
                Despesas.Add(item);
            }
        }
    }
}
