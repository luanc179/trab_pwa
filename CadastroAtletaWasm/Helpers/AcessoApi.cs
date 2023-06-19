using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using CadastroAtletaDll.DOs;
using System.Net.Http.Json;

namespace CadastroAtletasWasm.Helpers
{
    public class AcessoApi<T> where T : BaseDO
    {
        public AcessoApi(string api)
        {
            cliente.BaseAddress = new Uri("http://localhost:5039/");
            this.api = api;
        }

        public async Task<IList<T>?> RetornarTodosAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, api);
        
            var response = await cliente.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                
                return await JsonSerializer.DeserializeAsync
                    <IList<T>>(responseStream, options);
            }
            else
                return null;
        }

        public async Task<T?> RetornarPorIdAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, api + $"/{id}");
        
            var response = await cliente.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return (await JsonSerializer.DeserializeAsync
                    <T>(responseStream, options));
            }
            else
                return null;
        }

        public async Task<IList<T>?> RetornarPorIdMestreAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, api + $"/mestre/{id}");

            var response = await cliente.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await JsonSerializer.DeserializeAsync
                    <IList<T>>(responseStream, options);
            }
            else
                return null;
        }

        public async Task<T?> InserirAsync(T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, api);
        
            var data = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

            request.Content = data;
            
            var response = await cliente.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();

            return null;
        }

        public async Task<bool> AlterarAsync(T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, api + $"/{obj.Id}");
        
            var data = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

            request.Content = data;
            
            var response = await cliente.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ExcluirAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, api + $"/{id}");
        
            var response = await cliente.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        private string api;
        private HttpClient cliente = new HttpClient();
    }
}