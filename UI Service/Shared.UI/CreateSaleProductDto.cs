using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UI
{
    public class CreateSaleProductDto
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }

        public string? Notes { get; set; } = string.Empty;
    }
}
