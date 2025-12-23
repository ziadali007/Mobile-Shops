using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class AdminService
    {
        private readonly ApiGatewayClient _gateway;

        public AdminService(ApiGatewayClient gateway)
        {
            _gateway = gateway;
        }

        public async Task<bool> LoginAsync(string password)
        {
            var response = await _gateway.PostAsync("/Admin/login", new { password });

            return response.IsSuccessStatusCode;
        }
    }
}
