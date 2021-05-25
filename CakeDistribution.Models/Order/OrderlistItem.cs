using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Order
{
    public class OrderlistItem
    {
        public int OrderId { get; set; }
        [Display(Name="Date Ordered")]
        public DateTimeOffset CreatedUtc { get; set; }
        //[ForeignKey]
        //public int CustomerId { get; set; }
    }
}
