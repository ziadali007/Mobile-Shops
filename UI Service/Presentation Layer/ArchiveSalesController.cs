using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation_Layer
{
    public abstract class ArchiveSalesController : Controller
    {
        protected readonly ShopService _shopService;
        protected abstract string _adminPassword { get; }

        public ArchiveSalesController(ShopService shopService) 
        {
            _shopService = shopService;
        
        }

        protected string GetAdminPassword()
        {
            return HttpContext.Session.GetString("AdminPassword");
        }

        protected bool HasAdminPassword()
        {
            return !string.IsNullOrEmpty(GetAdminPassword());
        }

        protected IActionResult RequireAdminPassword()
        {
            var returnUrl = HttpContext.Request.Path + HttpContext.Request.QueryString;
            return RedirectToAction("EnterPassword", "Admin", new { returnUrl });
        }

        public virtual async Task<IActionResult> Index()
        {
            if (!HasAdminPassword())
                return RequireAdminPassword();

            var password = GetAdminPassword();

           if(password != _adminPassword)
           {
                return Forbid("Invalid Admin Password");
           }

            var response = await _shopService.GetArchivedSalesAsync(_adminPassword);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return View("~/Views/SharedProducts/ArchiveIndex.cshtml", new List<ArchiveDto>());
            }

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(json))
            {
                return View("~/Views/SharedProducts/ArchiveIndex.cshtml", new List<ArchiveDto>());
            }

            var data = JsonSerializer.Deserialize<List<ArchiveDto>>(json,
                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (data == null) throw new Exception("No Data Founded");

            return View("~/Views/SharedProducts/ArchiveIndex.cshtml", data);
        }

        [HttpGet]
        public virtual async Task<IActionResult> ArchiveByDate(DateTime date)
        {
            if (!HasAdminPassword())
                return RequireAdminPassword();
            var password = GetAdminPassword();
            if (password != _adminPassword)
            {
                return Forbid("Invalid Admin Password");
            }

            var response = await _shopService.GetArchiveByDate(password, date);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return View("~/Views/SharedProducts/ArchiveByDate.cshtml", null);
            }

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(json))
            {
                return View("~/Views/SharedProducts/ArchiveByDate.cshtml", new List<ArchiveItemDto>());
            }

            var data = JsonSerializer.Deserialize<List<ArchiveItemDto>>(json,
                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (data == null) throw new Exception("No Data Founded");

            return View("~/Views/SharedProducts/ArchiveByDate.cshtml", data);
        }
    }
}
