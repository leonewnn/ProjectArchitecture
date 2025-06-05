using MVC_Printer.Models;
using System.Text.Json;

namespace MVC_Printer.Services
{
    public class PrintService : IPrintService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly ILogger<PrintService> _logger;

        public PrintService(HttpClient client, IConfiguration configuration, ILogger<PrintService> logger)
        {
            _client = client;
            _baseUrl = configuration["WebAPI:BaseUrl"] ?? "https://localhost:7086/api/";
            _logger = logger;
        }

        public async Task<PrintQuotaViewModel> GetQuota(string userId)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}Print/GetQuota/{userId}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var apiResult = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return new PrintQuotaViewModel
                {
                    UserId = apiResult?.UserId ?? "",
                    QuotaChf = apiResult?.QuotaChf ?? 0,
                    Formats = apiResult?.Formats?.Select(f => new FormatPagesViewModel
                    {
                        TypeCode = f.TypeCode,
                        PagesAvailable = f.PagesAvailable
                    }).ToList() ?? new List<FormatPagesViewModel>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting quota for user {UserId}", userId);
                throw;
            }
        }

        private class ApiResponse
        {
            public string UserId { get; set; } = "";
            public decimal QuotaChf { get; set; }
            public List<ApiFormat> Formats { get; set; } = new();
        }

        private class ApiFormat
        {
            public string TypeCode { get; set; } = "";
            public int PagesAvailable { get; set; }
        }
    }
}