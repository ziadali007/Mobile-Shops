using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erChargerController : BaseProductController
    {
        public Elsha3erChargerController(Elsha3erShopService shopService)
            : base(shopService, "Charger") { }
    }
}
