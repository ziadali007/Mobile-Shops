using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UI
{
    public class ArchiveItemDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string? Notes { get; set; } = string.Empty;

        public DateTime ArchivedDate { get; set; }
    }
}
