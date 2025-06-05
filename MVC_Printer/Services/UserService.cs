using MVC_Printer.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Printer.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly ILogger<UserService> _logger;

        public UserService(HttpClient client, IConfiguration configuration, ILogger<UserService> logger)
        {
            _client = client;
            _baseUrl = configuration["WebAPI:BaseUrl"] ?? "https://localhost:7086/api/";
            _logger = logger;
        }

        public async Task AddMoney(AddMoneyViewModel request)
        {
            try
            {
                var dto = new
                {
                    CardId = request.CardId,
                    Username = request.Username,
                    Amount = request.Amount
                };

                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                _logger.LogInformation("Calling API: {Url}", $"{_baseUrl}User/AddMoney");

                var response = await _client.PostAsync($"{_baseUrl}User/AddMoney", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding money via API");
                throw;
            }
        }
    }
}