using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erScreenController : BaseProductController
    {
        public Elsha3erScreenController(Elsha3erShopService shopService)
            : base(shopService, "Screen", "Elsha3erSaleShop", "Elsha3er7579") { }
    }
}
