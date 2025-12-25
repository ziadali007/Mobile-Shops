using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Apple1ScreenController : BaseProductController
    {
        public Apple1ScreenController(AppleShopService shopService)
            : base(shopService, "Screen", "AppleSaleShop", "Tooms007")
        { }


    }
}
