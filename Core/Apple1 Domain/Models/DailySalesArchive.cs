using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Models
{
    public class DailySalesArchive : BaseEntity
    {
        public decimal? OriginalPrice { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string? Notes { get; set; } = string.Empty;

        public DateTime ArchivedDate { get; set; }
    }
}
