using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Order
{
    public class OrderListItem
    {
        public int OrderId { get; set; }
        [Display(Name ="Item Ordered")]
        public string ItemOrdered { get; set; }
        [Display(Name="Date Ordered")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int CustomerId { get; set; }
    }
}
