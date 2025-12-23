using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erProducts : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Elsha3erProducts/Index.cshtml");
        }
    }
}
