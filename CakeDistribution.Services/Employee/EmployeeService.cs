using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Services.Employee
{
    public class EmployeeService
    {
        private readonly Guid _userId;
        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }
    }
}
