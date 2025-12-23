using Business_Logic_Layer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class AuthController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public Microsoft.AspNetCore.Mvc.IActionResult Login()
          => View("~/Views/Auth/Login.cshtml"); 
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Login(string email, string password)
        {
            var success = await _authService.Login(email, password);
            if (!success)
            {
                ViewBag.Error = "Invalid email or password.";
                return View("~/Views/Auth/Login.cshtml");
            }
            var role = HttpContext.Session.GetString("role");
            return role == "Apple"
            ? RedirectToAction("Index", "AppleProducts")
            : RedirectToAction("Index", "Elsha3erProducts");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("AdminPassword");

            return RedirectToAction("Login", "Auth");
        }

    }
}
