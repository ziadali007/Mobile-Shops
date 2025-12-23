using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erWatchController : BaseProductController
    {
        public Elsha3erWatchController(Elsha3erShopService shopService)
            : base(shopService, "Watch") { }
    }
}
