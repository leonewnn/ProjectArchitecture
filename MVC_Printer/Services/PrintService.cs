using MVC_Printer.Models;
using System.Text.Json;

namespace MVC_Printer.Services
{
    public class PrintService : IPrintService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public PrintService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
           _baseUrl = configuration["WebAPI:BaseUrl"];
        }

        public async Task<PrintQuotaViewModel> GetQuota(string userId)
        {
            var response = await _client.GetAsync($"{_baseUrl}Print/GetQuota/{userId}");
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var quota = JsonSerializer.Deserialize<PrintQuotaViewModel>(json, options);
            return quota;
        }
    }
}