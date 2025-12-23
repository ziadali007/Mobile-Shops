using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ShopService : BaseShopService
    {
        private readonly string _prefix;
        public ShopService(ApiGatewayClient gateway, string shopPrefix)
            : base(gateway, shopPrefix)
        {
            _prefix = shopPrefix;
        }

        private string Build(string entity, string extra = "")
        => $"{_prefix}/{entity}{extra}";

        private string Protected(string entity, string extra = "")
            => $"{_prefix}/protected/{entity}{extra}";

        public Task<HttpResponseMessage> GetAllAsync(string entity)
            => _gateway.GetAsync(Build(entity));

        public Task<HttpResponseMessage> GetByNameAsync(string entity, string name)
            => _gateway.GetAsync(Build(entity, $"/{name}"));

        public Task<HttpResponseMessage> CreateAsync(string entity, object dto, string? password)
            => _gateway.ProtectedPostAsync(Protected(entity), dto, password);

        public Task<HttpResponseMessage> UpdateAsync(string entity, object dto, string password)
            => _gateway.ProtectedPutAsync(Protected(entity), dto, password);

        public Task<HttpResponseMessage> DeleteAsync(string entity, int id, string password)
            => _gateway.ProtectedDeleteAsync(Protected(entity, $"/{id}"), password);

        // SALES
        public Task<HttpResponseMessage> GetSalesAsync()
            => _gateway.GetAsync($"{_prefix}/Sale");

        public Task<HttpResponseMessage> CreateSaleAsync(object dto)
            => _gateway.PostAsync($"{_prefix}/Sale", dto);

        public Task<HttpResponseMessage> DeleteSaleAsync(int id)
            => _gateway.DeleteAsync($"{_prefix}/Sale/{id}");

        // ARCHIVE SALES
        public Task<HttpResponseMessage> GetArchivedSalesAsync(string password)
            => _gateway.ProtectedGetAsync($"{_prefix}/protected/ArchiveDailySales", password);

        public Task<HttpResponseMessage> ArchiveSalesAsync(string password)
            => _gateway.ProtectedPostAsync($"{_prefix}/protected/ArchiveDailySales", null, password);

        public Task<HttpResponseMessage> GetArchiveByDate(string password, DateTime date)
            => _gateway.ProtectedGetAsync(
                $"{_prefix}/protected/ArchiveDailySales/{date:yyyy-MM-dd}",
                password
            );

    }
}
