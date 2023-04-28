using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ConsoleApp111.Models;
using System.Net.Http;
using Newtonsoft.Json;
namespace ConsoleApp111.Clients
{
    public class RecipesClients
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;

        public RecipesClients()
        {
            _address = Constants.address;
            _apikey = Constants.apikey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apikey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _address);
        }

        public async Task<string> GetRecipeAsync(string query)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://recipe-by-api-ninjas.p.rapidapi.com/v1/recipe?query={query}")
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
       
    }
}
