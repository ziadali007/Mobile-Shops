using Auth_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(JwtService jwtService) : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if(loginRequest.Email == "apple@shop.com" &&  loginRequest.Password == "apple123")
            {
                var token= jwtService.GenerateToken("apple@shop.com", "Apple");
                return Ok(new { Token = token, role="Apple" });
            }
            else if(loginRequest.Email == "elsha3er@shop.com" && loginRequest.Password == "elsha3er456")
            {
                var token = jwtService.GenerateToken("elsha3er@shop.com", "Elsha3er");
                return Ok(new { Token = token, role = "Elsha3er" });
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }

    }
}
