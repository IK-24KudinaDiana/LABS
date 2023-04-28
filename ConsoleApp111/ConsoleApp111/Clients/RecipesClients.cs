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

        //public RecipesClients()
        //{
        //    _address = Constants.address;
        //    _apikey = Constants.apikey;
        //    _httpClient = new HttpClient();
        //    _httpClient.BaseAddress = new Uri(_address);
        //}
        //private readonly HttpClient client;

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
        //public async Task<Recipes> GetRecipesAsync()
        //{

        //}
        //////var client = new HttpClient();
        ////    var request = new HttpRequestMessage
        ////    {
        ////        Method = HttpMethod.Get,
        ////        RequestUri = new Uri("https://recipe-by-api-ninjas.p.rapidapi.com/v1/recipe?query=borsch"),
        ////        Headers =
        ////    {
        ////        { "X-RapidAPI-Key", "34d7f3c379mshf511c2d5acb645fp1ddca2jsn939b03ca067e" },
        ////        { "X-RapidAPI-Host", "recipe-by-api-ninjas.p.rapidapi.com" },
        ////    },
        ////    };
        ////using (var response = await client.SendAsync(request))
        ////{
        //// response.EnsureSuccessStatusCode();
        //// var body = await response.Content.ReadAsStringAsync();
        ////    Console.WriteLine(body);
        ////}
    }
}
