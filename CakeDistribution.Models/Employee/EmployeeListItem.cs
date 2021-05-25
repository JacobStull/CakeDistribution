using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Employee
{
    public class EmployeeListItem
    {
        [Display(Name = "Id")]
        public int EmplyeeId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
    }
}
