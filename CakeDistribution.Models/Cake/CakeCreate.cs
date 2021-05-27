using CakeDistribution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Cake
{
    public class CakeCreate
    {
        [ForeignKey(nameof(Dessert))]
        public int DessertId { get; set; }
        public virtual Desserts Dessert { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name ="Name")]
        public string CakeName { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name = "Topping")]
        public string CakeIcing { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
    }
}
