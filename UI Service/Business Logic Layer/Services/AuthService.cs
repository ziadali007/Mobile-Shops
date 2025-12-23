using Business_Logic_Layer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class AuthService : IAuthService
    {
        protected readonly ApiGatewayClient _gateway;
        protected readonly IHttpContextAccessor _accessor;

        public AuthService(ApiGatewayClient client, IHttpContextAccessor accessor)
        {
            _gateway = client;
            _accessor = accessor;
        }
        public async Task<bool> Login(string email, string password)
        {
            var body = new { email, password };

            // Call Auth Service through Ocelot
            var response = await _gateway.PostAsync("/Auth/login", body);

            if (!response.IsSuccessStatusCode)
                return false;

            // Read JSON string
            string jsonString = await response.Content.ReadAsStringAsync();

            // Parse
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);

            string token = json.token;
            string role = json.role;

            // Save in session
            _accessor.HttpContext.Session.SetString("token", token);
            _accessor.HttpContext.Session.SetString("role", role);

            return true;

        }
    }
}
