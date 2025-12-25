using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Apple1OtherController : BaseProductController
    {
        public Apple1OtherController(AppleShopService shopService)
            : base(shopService, "Others", "AppleSaleShop", "Tooms007")
        {
        }
    }
}
