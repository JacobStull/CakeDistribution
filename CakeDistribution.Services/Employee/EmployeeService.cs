using CakeDistribution.Data;
using CakeDistribution.Models.Employee;
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

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employees()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    JobTitle = model.JobTitle
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EmployeeListItem
                                {
                                    EmployeeId = e.EmployeeId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    JobTitle = e.JobTitle
                                }
                            );
                return query.ToArray();
            }
        }
    }
}
