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
using System.Web.Mvc;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;

namespace Presentation_Layer
{
    public class BaseProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly ShopService _shopService;
        protected readonly string _productEndpoint;

        protected BaseProductController(ShopService service, string entity)
        {
            _shopService = service;
            _productEndpoint = entity;
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
            if (string.IsNullOrEmpty(_productEndpoint))
                return BadRequest("Product endpoint is required");

            var response = await _shopService.GetAllAsync(_productEndpoint);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return View("~/Views/SharedProducts/Index.cshtml", new List<ProductDto>());
            }

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(json))
            {
                return View("~/Views/SharedProducts/Index.cshtml", new List<ProductDto>());
            }

            var data = JsonSerializer.Deserialize<List<ProductDto>>(json,
                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if(data ==  null) throw new Exception("No Data Founded");

            return View("~/Views/SharedProducts/Index.cshtml", data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!HasAdminPassword())
                return RequireAdminPassword();
            var password=GetAdminPassword();

            if(password == "Tooms007" || password == "Elsha3er7579")
            {
                return View(viewName: "~/Views/SharedProducts/Create.cshtml");

            }

            return RequireAdminPassword();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var password = GetAdminPassword();

            var response = await _shopService.ProtectedPostAsync(
                $"protected/{_productEndpoint}",
                dto,
                password
            );

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View("~/Views/SharedProducts/Create.cshtml");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!HasAdminPassword())
                return RequireAdminPassword();

            var password = GetAdminPassword();

            var response = await _shopService.GetAsync($"{_productEndpoint}/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var json = await response.Content.ReadAsStringAsync();

            var dto = JsonSerializer.Deserialize<UpdateProductDto>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );


            if (password == "Tooms007" || password == "Elsha3er7579")
            {
                return View(viewName: "~/Views/SharedProducts/Edit.cshtml",dto);

            }

            return RequireAdminPassword();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto dto)
        {
            var password= GetAdminPassword();
            if (!ModelState.IsValid)
                return View("~/Views/SharedProducts/Edit.cshtml", dto);

            var response = await _shopService.ProtectedPutAsync(
                $"protected/{_productEndpoint}",
                dto,
                password
            );

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View("~/Views/SharedProducts/Edit.cshtml", dto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            if (!HasAdminPassword())
                return RequireAdminPassword();

            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var password = GetAdminPassword();

            if (password != "Tooms007" && password != "Elsha3er7579")
                return View("~/Views/Shared/Error.cshtml");

            var response = await _shopService.ProtectedDeleteAsync(
                $"protected/{_productEndpoint}/{id}",
                password
            );

            if (!response.IsSuccessStatusCode)
                TempData["Error"] = await response.Content.ReadAsStringAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
