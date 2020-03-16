using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ComicSharedModels;
using Microsoft.Extensions.Configuration;
namespace ComicClient
{
    public class ComicService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ComicService(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _configuration = configuration;
        }

        public async Task<ComicModel> GetMostRecentComicAsync()
        {
            var uri = new Uri(_configuration.GetValue<string>("ComicApiURL") + "info.0.json");
            var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ComicModel>(data);
        }
    }
}
