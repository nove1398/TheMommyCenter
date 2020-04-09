using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Providers
{
    public class HttpProvider
    {
        private HttpClient _client ;
        private readonly TokenAuthProvider _provider;

        public HttpProvider(TokenAuthProvider provider) 
        {
            _client = new HttpClient();
            _provider = provider;
        }

        public HttpProvider(string baseUrl, TokenAuthProvider provider)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _provider = provider;
        }


        public void InitClientToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        private async Task AddAuthToken()
        {
            if (_provider != null )
            {
                var toke = await _provider.GetTokenAsync();
                if(!string.IsNullOrEmpty(toke))
                    _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", toke);
            }
            
        }

        public async Task<T> PostAsync<T>(string url, object model, string apiversion = null)
        {
            await AddAuthToken();
            if (!string.IsNullOrEmpty(apiversion))
                _client.DefaultRequestHeaders.Add("X-Version", apiversion);
            var json = JsonConvert.SerializeObject(model);
            var payLoad = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, payLoad);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

        public async Task<T> GetAsync<T>(string url, string apiversion = null)
        {
            await AddAuthToken();
            if (!string.IsNullOrEmpty(apiversion))
                _client.DefaultRequestHeaders.Add("X-Version", apiversion);
            var result = await _client.GetAsync(url);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

        public async Task<List<T>> GetListAsync<T>(string url, string apiversion = null)
        {
            await AddAuthToken();
            if (!string.IsNullOrEmpty(apiversion))
                _client.DefaultRequestHeaders.Add("X-Version", apiversion);
            var result = await _client.GetAsync(url);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<T>>(answer);
            return data;
        }

        public async Task<T> DeleteAsync<T>(string url, int id, string apiversion = null)
        {
            await AddAuthToken();
            if (!string.IsNullOrEmpty(apiversion))
                _client.DefaultRequestHeaders.Add("X-Version", apiversion);
            var result = await _client.DeleteAsync($"{url}/{id}");
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

        public async Task<T> PutAsync<T>(string url, object model, string apiversion = null)
        {
            await AddAuthToken();
            if (!string.IsNullOrEmpty(apiversion))
                _client.DefaultRequestHeaders.Add("X-Version", apiversion);
            var json = JsonConvert.SerializeObject(model);
            var payLoad = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(url, payLoad);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }
    }
}
