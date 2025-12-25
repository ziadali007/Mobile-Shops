using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class AppleSaleShopController : SaleController
    {
        protected override string _productEndpoint => "Sale";

        public AppleSaleShopController(AppleShopService shopService)
            : base(shopService)
        {
        }
    }
}
