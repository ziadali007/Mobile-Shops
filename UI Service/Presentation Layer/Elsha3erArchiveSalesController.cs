using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class Elsha3erArchiveSalesController : ArchiveSalesController
    {
        protected override string _adminPassword => "Elsha3er7579";
        public Elsha3erArchiveSalesController(Elsha3erShopService shopService)
            : base(shopService)
        {
        }
    }
}
