using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erSaleShopController : SaleController
    {
        protected override string _productEndpoint => "Sale";

        public Elsha3erSaleShopController(Elsha3erShopService shopService)
            : base(shopService)
        {
        }
    }
}
