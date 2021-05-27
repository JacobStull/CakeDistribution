using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Order
{
    public class OrderEdit
    {
        public int OrderId { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public string ItemOrdered { get; set; }
    }
}
