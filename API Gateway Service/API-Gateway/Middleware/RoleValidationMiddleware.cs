using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API_Gateway.Middleware
{
    public class RoleValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public RoleValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();
            if(path != null && path.Contains("/auth"))
            {
                await _next(context);
                return;
            }
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Missing or invalid Authorization header");
                return;
            }

            var token = authHeader.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt;

            try
            {
                jwt = handler.ReadJwtToken(token);
            }
            catch
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid token format");
                return;
            }

            var role = jwt.Claims.FirstOrDefault(c => c.Type == "role")?.Value;


            if (string.IsNullOrEmpty(role))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Role not found in token");
                return;
            }

            if (path!.Contains("apple1") && role != "Apple")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Access denied: Apple role required");
                return;
            }

            if (path.Contains("elsha3er") && role != "Elsha3er")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Access denied: Elsha3er role required");
                return;
            }

            // Only check password for protected routes
            if (path.Contains("/apple1/protected"))
            {
                if (!context.Request.Headers.TryGetValue("Admin-Password", out var password))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Admin-Password header is required.");
                    return;
                }

                if (password != "Tooms007")
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Invalid Admin Password.");
                    return;
                }
            }

            if (path.Contains("/elsha3er/protected"))
            {
                if (!context.Request.Headers.TryGetValue("Admin-Password", out var password))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Admin-Password header is required.");
                    return;
                }

                if (password != "Elsha3er7579")
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Invalid Admin Password.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
