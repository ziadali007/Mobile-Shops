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
    public class SaleController : Controller
    {
        protected readonly ShopService _shopService;

        protected SaleController(ShopService shopService)
        {
            _shopService = shopService;
        }

        public virtual async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty("Sale"))
                return BadRequest("Product endpoint is required");

            var response = await _shopService.GetAllAsync("Sale");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return View("~/Views/SharedProducts/Index.cshtml", new List<SaleProductDto>());
            }

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(json))
            {
                return View("~/Views/SharedProducts/Index.cshtml", new List<SaleProductDto>());
            }

            var data = JsonSerializer.Deserialize<List<SaleProductDto>>(json,
                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (data == null) throw new Exception("No Data Founded");

            return View("~/Views/SharedProducts/SaleIndex.cshtml", data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(CreateSaleProductDto dto)
        {
            if (string.IsNullOrEmpty("Sale"))
                return BadRequest("Product endpoint is required");
            var response = await _shopService.CreateSaleAsync(dto);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API Error: {response.StatusCode}";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (string.IsNullOrEmpty("Sale"))
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
