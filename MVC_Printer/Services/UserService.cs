using MVC_Printer.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Printer.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public UserService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _baseUrl = configuration["WebAPI:BaseUrl"];
        }

        public async Task AddMoney(AddMoneyViewModel request)
        {
            var response = await _client.PostAsJsonAsync($"{_baseUrl}User/AddMoney", request);
            response.EnsureSuccessStatusCode();
        }
    }
}