using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class Elsha3erShopService : ShopService
    {
        public Elsha3erShopService(ApiGatewayClient gateway)
        : base(gateway, "/Elsha3er") { }
    }
}
