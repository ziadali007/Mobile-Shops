using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class BaseShopService
    {
        protected readonly ApiGatewayClient _gateway;
        protected readonly string _basePath;
        public BaseShopService(ApiGatewayClient gateway, string basePath)
        {
            _gateway = gateway;
            _basePath = basePath;
        }

        protected string Url(string endpoint)
        {
            return $"{_basePath}/{endpoint}".TrimEnd('/');
        }


        public Task<HttpResponseMessage> GetAsync(string endpoint)
            => _gateway.GetAsync(Url(endpoint));


        public Task<HttpResponseMessage> PostAsync(string endpoint, object body)
            => _gateway.PostAsync(Url(endpoint), body);

        public Task<HttpResponseMessage> PutAsync(string endpoint, object body)
            => _gateway.PutAsync(Url(endpoint), body);

        public Task<HttpResponseMessage> DeleteAsync(string endpoint)
            => _gateway.DeleteAsync(Url(endpoint));


        public Task<HttpResponseMessage> ProtectedPostAsync(string endpoint, object body, string adminPassword)
            => _gateway.ProtectedPostAsync(Url(endpoint), body, adminPassword);

        public Task<HttpResponseMessage> ProtectedPutAsync(string endpoint, object body, string adminPassword)
            => _gateway.ProtectedPutAsync(Url(endpoint), body, adminPassword);

        public Task<HttpResponseMessage> ProtectedDeleteAsync(string endpoint, string adminPassword)
            => _gateway.ProtectedDeleteAsync(Url(endpoint), adminPassword);

        public Task<HttpResponseMessage> ProtectedGetAsync(string endpoint, string adminPassword)
            => _gateway.ProtectedGetAsync(Url(endpoint), adminPassword);
    }
}
