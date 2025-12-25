using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public  class AppleArchiveSalesController : ArchiveSalesController
    {
        protected override string _adminPassword  => "Tooms007";
        public AppleArchiveSalesController(AppleShopService shopService) : base(shopService)
        {
        }
    }
}
