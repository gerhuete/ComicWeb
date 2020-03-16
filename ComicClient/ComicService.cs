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
        public async Task<ComicModel> GetComicByNumAsync(int num)
        {
            try
            {
                var uri = new Uri(_configuration.GetValue<string>("ComicApiURL") + num.ToString() + "/info.0.json");
                var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ComicModel>(data);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ComicModel> GetPreviousComicByNumAsync(int num)
        {
            var prevNum = num - 1;
            ComicModel comic = new ComicModel();
            comic = GetComicByNumAsync(prevNum).Result;
            if (comic==null) {
                comic = await GetComicByNumAsync(num);
            }
            return comic;
        }

        public async Task<ComicModel> GetNextComicByNumAsync(int num)
        {
            var nextNum = num + 1;
            ComicModel comic = new ComicModel();
            comic = GetComicByNumAsync(nextNum).Result;
            if (comic == null)
            {
                comic = await GetComicByNumAsync(num);
            }
            return comic;
        }
    }
}
