using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Dessert
{
    public class DessertEdit
    {
        [Required]
        public int DessertId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name = "Name")]
        public string DessertName { get; set; }
    }
}
