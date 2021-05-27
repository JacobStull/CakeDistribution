using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Data
{
    public class Desserts
    {
        [Key]
        public int DessertId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string DessertName { get; set; }
        public virtual ICollection<Cakes> Cake { get; set; } = new List<Cakes>();

    }
}
