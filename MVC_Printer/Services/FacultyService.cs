using MVC_Printer.Models;
using System.Text.Json;

namespace MVC_Printer.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly ILogger<FacultyService> _logger;

        public FacultyService(HttpClient client, IConfiguration configuration, ILogger<FacultyService> logger)
        {
            _client = client;
            _baseUrl = configuration["WebAPI:BaseUrl"] ?? "https://localhost:7086/api/";
            _logger = logger;
        }

        public async Task<List<FacultyViewModel>> GetFaculties()
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}Faculty/GetFaculties");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var faculties = JsonSerializer.Deserialize<List<ApiFaculty>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return faculties?.Select(f => new FacultyViewModel
                {
                    FacultyId = f.FacultyId,
                    Name = f.Name
                }).ToList() ?? new List<FacultyViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting faculties");
                throw;
            }
        }

        public async Task<List<UserBalanceViewModel>> GetUsersByFaculty(int facultyId)
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}Faculty/GetUsersByFaculty/{facultyId}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<ApiUserBalance>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return users?.Select(u => new UserBalanceViewModel
                {
                    Uid = u.Uid,
                    Username = u.Username,
                    Balance = u.Balance
                }).ToList() ?? new List<UserBalanceViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users for faculty {FacultyId}", facultyId);
                throw;
            }
        }

        private class ApiFaculty
        {
            public int FacultyId { get; set; }
            public string Name { get; set; } = "";
        }

        private class ApiUserBalance
        {
            public string Uid { get; set; } = "";
            public string Username { get; set; } = "";
            public decimal Balance { get; set; }
        }
    }
}