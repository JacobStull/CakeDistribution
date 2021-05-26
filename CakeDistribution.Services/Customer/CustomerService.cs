using CakeDistribution.Data;
using CakeDistribution.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Services.Customer
{
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customers()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ActiveCustomers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ActiveCustomers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Address = e.Address
                                }
                            );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveCustomers
                        .Single(e => e.CustomerId == id && e.OwnerId == _userId);
                return
                      new CustomerDetail
                      {
                          CustomerId = entity.CustomerId,
                          FirstName = entity.FirstName,
                          LastName = entity.LastName,
                          Address = entity.Address

                      };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveCustomers
                        .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveCustomers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);

                ctx.ActiveCustomers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
