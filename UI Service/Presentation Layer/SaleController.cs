using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public abstract class SaleController : Controller
    {
        protected readonly ShopService _shopService;
        protected abstract string _productEndpoint { get; }
        public SaleController(ShopService shopService)
        {
            _shopService = shopService;
        }


        public virtual async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(_productEndpoint))
                return BadRequest("Product endpoint is required");

            var response = await _shopService.GetAllAsync(_productEndpoint);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return View("~/Views/SharedProducts/SaleIndex.cshtml", new List<SaleProductDto>());
            }

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(json))
            {
                return View("~/Views/SharedProducts/SaleIndex.cshtml", new List<SaleProductDto>());
            }

            var data = JsonSerializer.Deserialize<List<SaleProductDto>>(json,
                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (data == null) throw new Exception("No Data Founded");

            return View("~/Views/SharedProducts/SaleIndex.cshtml", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Add(ProductDto dto, string notes)
        {
            if (string.IsNullOrEmpty(_productEndpoint))
                return BadRequest("Product endpoint is required");

            var Saledto = new CreateSaleProductDto()
            {
                ProductId = dto.Id,
                ProductType=dto.Type,
                Quantity=dto.Quantity,
                Notes = notes
            };
            var response = await _shopService.CreateSaleAsync(Saledto);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (string.IsNullOrEmpty(_productEndpoint))
                return BadRequest("Product endpoint is required");
            var response = await _shopService.DeleteSaleAsync(id);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
