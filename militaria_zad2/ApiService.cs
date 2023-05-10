using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace militaria_zad2
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ObjectModel>> GetAreas()
        {
            var response = await _httpClient.GetAsync("https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var areas = JsonSerializer.Deserialize<List<ObjectModel>>(responseContent, options);
            return areas;
        }
    }
}
