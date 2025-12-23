using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class AppleShopService : ShopService
    {
        public AppleShopService(ApiGatewayClient gateway)
         : base(gateway, "/Apple1") { }

    }
}
