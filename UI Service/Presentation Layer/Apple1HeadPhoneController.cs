using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Apple1HeadPhoneController : BaseProductController
    {
        public Apple1HeadPhoneController(AppleShopService shopService)
            : base(shopService, "HeadPhone")
        {
        }
    }
}
