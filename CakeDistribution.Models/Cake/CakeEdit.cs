using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Cake
{
    public class CakeEdit
    {
        public int CakeId { get; set; }
        public string DessertName { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name = "Name")]
        public string CakeName { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [Display(Name = "Topping")]
        public string CakeIcing { get; set; }
        public string Description { get; set; }
    }
}
