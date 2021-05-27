using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Data
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string ItemOrdered { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
