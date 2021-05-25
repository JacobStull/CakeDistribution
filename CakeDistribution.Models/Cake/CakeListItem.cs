using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Cake
{
    public class CakeListItem
    {
        [Display(Name = "Id")]
        public int CakeId { get; set; }
        [Display(Name = "Cake")]
        public string CakeName { get; set; }
        [Display(Name = "Icing")]
        public string CakeIcing { get; set; }
        public string Description { get; set; }
    }
}
