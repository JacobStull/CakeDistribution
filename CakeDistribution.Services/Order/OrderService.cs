using CakeDistribution.Data;
using CakeDistribution.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Services.Order
{
    public class OrderService
    {
        private readonly Guid _userId;
        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Orders()
                {
                    OwnerId = _userId,
                    ItemOrdered = model.ItemOrdered,
                    CustomerId = model.CustomerId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ActiveOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ActiveOrders
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    ItemOrdered = e.ItemOrdered,
                                    CreatedUtc = e.CreatedUtc,
                                    CustomerId = e.CustomerId
                                }
                            );
                return query.ToArray();
            }
        }

        public OrderDetail GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveOrders
                        .Single(e => e.OrderId == id && e.OwnerId == _userId);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        ItemOrdered = entity.ItemOrdered,
                        CreatedUtc = entity.CreatedUtc,
                        CustomerId = entity.CustomerId
                    };

            }
        }

        public bool UpdateOrder(OrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveOrders
                        .Single(e => e.OrderId == model.OrderId && e.OwnerId == _userId);
                entity.ItemOrdered = model.ItemOrdered;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveOrders
                        .Single(e => e.OrderId == orderId && e.OwnerId == _userId);

                ctx.ActiveOrders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

