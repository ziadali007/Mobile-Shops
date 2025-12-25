using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erCoverController : BaseProductController
    {
        public Elsha3erCoverController(Elsha3erShopService shopService)
            : base(shopService, "Cover", "Elsha3erSaleShop", "Elsha3er7579") { }
    }
}
