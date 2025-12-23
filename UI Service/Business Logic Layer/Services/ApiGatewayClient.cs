using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ApiGatewayClient
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;

        public ApiGatewayClient(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _accessor = httpContextAccessor;
            _client.BaseAddress = new Uri("http://localhost:5030");
        }

        private void AttachJwtToken(HttpRequestMessage request)
        {
            var token = _accessor.HttpContext?.Session?.GetString("token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<HttpResponseMessage> SendAsync(
            HttpMethod method,
            string url,
            object body = null,
            string adminPassword = null)
        {
            var request = new HttpRequestMessage(method, url);

            // Token is always required
            AttachJwtToken(request);

            if (!string.IsNullOrWhiteSpace(adminPassword))
            {
                request.Headers.Remove("Admin-Password");
                request.Headers.Add("Admin-Password", adminPassword);
            }

            if (body != null)
            {
                var json = JsonSerializer.Serialize(body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            return await _client.SendAsync(request);
        }

        public Task<HttpResponseMessage> GetAsync(string url)
            => SendAsync(HttpMethod.Get, url);

        public Task<HttpResponseMessage> ProtectedGetAsync(string url, string adminPassword)
            => SendAsync(HttpMethod.Get, url, null, adminPassword);

        public Task<HttpResponseMessage> PostAsync(string url, object data)
            => SendAsync(HttpMethod.Post, url, data);

        //Protected endpoints with admin password
        public Task<HttpResponseMessage> ProtectedPostAsync(string url, object data, string adminPassword)
            => SendAsync(HttpMethod.Post, url, data, adminPassword);

        public Task<HttpResponseMessage> PutAsync(string url, object data)
            => SendAsync(HttpMethod.Put, url, data);

        public Task<HttpResponseMessage> DeleteAsync(string url)
            => SendAsync(HttpMethod.Delete, url);

        public Task<HttpResponseMessage> ProtectedPutAsync(string url, object data, string adminPassword)
            => SendAsync(HttpMethod.Put, url, data, adminPassword);

        public Task<HttpResponseMessage> ProtectedDeleteAsync(string url, string adminPassword)
            => SendAsync(HttpMethod.Delete, url,null, adminPassword);

    }
}
    