using API_Gateway.Middleware;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API_Gateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            builder.Services.AddOcelot().AddCacheManager(x =>
            {
                x.WithDictionaryHandle();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication()
                     .AddJwtBearer("Bearer", options =>
                     {
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidateIssuerSigningKey = true,
                             ValidIssuer = "AuthService",
                             ValidAudience = "ShopUsers",
                             IssuerSigningKey = new SymmetricSecurityKey(
                                 Encoding.UTF8.GetBytes("THIS_IS_A_VERY_LONG_SECRET_KEY_MORE_THAN_32_CHARACTERS!!!!")),


                             RoleClaimType = "role",
                             NameClaimType = "email"
                         };
                         options.MapInboundClaims = false;
                     });


            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<RoleValidationMiddleware>();


            await app.UseOcelot();
            // Configure the HTTP request pipeline.



            app.Run();
        }
    }
}
