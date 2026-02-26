using System.Net.Http.Json;
using EfforeFinance.App.Models;

namespace EfforeFinance.App.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        private readonly string _baseUrl = DeviceInfo.Platform == DevicePlatform.Android
            ? "https://10.0.2.2:7088/api"
            : "https://localhost:7088/api";

        public ApiService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _http = new HttpClient(handler);
        }
        
        public async Task<decimal> ObterSaldoContaAsync(int idConta)
        {
            try
            {
                var resposta = await _http.GetFromJsonAsync<RespostaSaldo>($"{_baseUrl}/dashboard/saldo/{idConta}");
                return resposta?.SaldoAtual ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<ResumoDespesa>> ObterResumoDespesasAsync(int idUsuario, int mes, int ano)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<ResumoDespesa>>($"{_baseUrl}/dashboard/resumo/{idUsuario}/{mes}/{ano}")
                                       ?? new List<ResumoDespesa>();
            }
            catch
            {
                return new List<ResumoDespesa>();
            }
        }
    }
    
    public class RespostaSaldo
    {
        public decimal SaldoAtual { get; set; }
    }
}
