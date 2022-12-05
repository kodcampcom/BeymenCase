using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models
{
    public class ProductRequestDto
    {
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
