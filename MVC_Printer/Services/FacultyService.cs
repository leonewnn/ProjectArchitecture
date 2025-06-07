using MVC_Printer.Models;
using System.Text.Json;

namespace MVC_Printer.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public FacultyService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _baseUrl = configuration["WebAPI:BaseUrl"];
        }

        public async Task<List<FacultyViewModel>> GetFaculties()
        {
            var response = await _client.GetAsync(_baseUrl + "Faculty/GetFaculties");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var faculties = JsonSerializer.Deserialize<List<FacultyViewModel>>(responseBody, options);
            return faculties;
        }

        public async Task<List<UserBalanceViewModel>> GetUsersByFaculty(int facultyId)
        {
            var response = await _client.GetAsync(_baseUrl + "Faculty/GetUsersByFaculty/" + facultyId);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var users = JsonSerializer.Deserialize<List<UserBalanceViewModel>>(responseBody, options);
            return users;
        }
    }
}