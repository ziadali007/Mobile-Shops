using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erHeadPhoneController : BaseProductController
    {
        public Elsha3erHeadPhoneController(Elsha3erShopService shopService)
            : base(shopService, "HeadPhone", "Elsha3erSaleShop", "Elsha3er7579") { }
    }
}
