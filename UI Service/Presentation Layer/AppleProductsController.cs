using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class AppleProductsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/AppleProducts/Index.cshtml");
        }
    }
}
