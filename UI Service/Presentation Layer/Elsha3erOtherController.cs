using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erOtherController : BaseProductController
    {
        public Elsha3erOtherController(Elsha3erShopService shopService)
            : base(shopService, "Others", "Elsha3erSaleShop", "Elsha3er7579") { }
    }
}
