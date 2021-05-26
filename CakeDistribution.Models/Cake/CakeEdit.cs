using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Cake
{
    public class CakeEdit
    {
        public int CakeId { get; set; }
        public string CakeName { get; set; }
        public string CakeIcing { get; set; }
        public string Description { get; set; }
    }
}
