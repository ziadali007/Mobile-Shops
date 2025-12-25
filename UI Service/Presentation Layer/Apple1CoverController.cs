using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Apple1CoverController : BaseProductController
    {
        public Apple1CoverController(AppleShopService appleShop) : base (appleShop , "Cover", "AppleSaleShop", "Tooms007") { }

    }
}
