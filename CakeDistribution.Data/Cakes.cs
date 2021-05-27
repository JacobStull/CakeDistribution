using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Data
{
    public class Cakes
    {
        [Key]
        public int CakeId { get; set; }
        [ForeignKey(nameof(Dessert))]
        public int DessertId { get; set; }
        
        public virtual Desserts Dessert { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string CakeName { get; set; }
        [Required]
        public string CakeIcing { get; set; }
        [Required]
        public string Description { get; set; }
        

    }
}
