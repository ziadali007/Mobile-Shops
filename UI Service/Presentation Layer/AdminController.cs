using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _accessor;

        public AdminController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [HttpGet]
        public IActionResult EnterPassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult EnterPassword(string password, string returnUrl)
        {
            _accessor.HttpContext.Session.SetString("AdminPassword", password);
            return Redirect(returnUrl);
        }
    }
}
