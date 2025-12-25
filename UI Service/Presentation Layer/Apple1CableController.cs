using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Apple1CableController : BaseProductController
    {

        public Apple1CableController(AppleShopService shopService)
            : base(shopService, "Cable", "AppleSaleShop","Tooms007") { }
    }
}
