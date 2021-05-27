using CakeDistribution.Data;
using CakeDistribution.Models.Dessert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Services.Dessert
{
    public class DessertService
    {
        private readonly Guid _userId;
        public DessertService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDessert(DessertCreate model)
        {
            var entity =
                new Desserts()
                {
                    OwnerId = _userId,
                    DessertName = model.DessertName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ActiveDesserts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DessertListItem> GetDesserts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ActiveDesserts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DessertListItem
                                {
                                    DessertId = e.DessertId,
                                    DessertName = e.DessertName
                                }
                            );
                return query.ToArray();
            }
        }

        public DessertDetail GetDessertById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveDesserts
                        .Single(e => e.DessertId == id && e.OwnerId == _userId);
                return
                    new DessertDetail
                    {
                        DessertId = entity.DessertId,
                        DessertName = entity.DessertName
                    };

            }
        }

        public bool UpdateDessert(DessertEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveDesserts
                        .Single(e => e.DessertId == model.DessertId && e.OwnerId == _userId);
                entity.DessertName = model.DessertName;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteDessert(int dessertId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveDesserts
                        .Single(e => e.DessertId == dessertId && e.OwnerId == _userId);

                ctx.ActiveDesserts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
