using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erCableController : BaseProductController
    {
        public Elsha3erCableController(Elsha3erShopService shopService)
            : base(shopService, "Cable", "Elsha3erSaleShop", "Elsha3er7579") { }
    }
}
