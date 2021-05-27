using CakeDistribution.Data;
using CakeDistribution.Models.Cake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Services.Cake
{
    public class CakeService
    {
        private readonly Guid _userId;
        public CakeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCake(CakeCreate model)
        {
            var entity =
                new Cakes()
                {
                    OwnerId = _userId,
                    DessertName = model.DessertName,
                    CakeName = model.CakeName,
                    CakeIcing = model.CakeIcing,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ActiveCakes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CakeListItem> GetCakes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ActiveCakes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CakeListItem
                                {
                                    CakeId = e.CakeId,
                                    CakeName = e.CakeName,
                                    CakeIcing = e.CakeIcing,
                                    Description = e.Description
                                }
                            );
                return query.ToArray();
            }
        }

        public CakeDetail GetCakeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveCakes
                        .Single(e => e.CakeId == id && e.OwnerId == _userId);
                return
                    new CakeDetail
                    {
                        CakeId = entity.CakeId,
                        CakeName = entity.CakeName,
                        CakeIcing = entity.CakeIcing,
                        Description = entity.Description
                    };

            }
        }

        public bool UpdateCake(CakeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveCakes
                        .Single(e => e.CakeId == model.CakeId && e.OwnerId == _userId);
                entity.CakeName = model.CakeName;
                entity.CakeIcing = model.CakeIcing;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteCake(int cakeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ActiveCakes
                        .Single(e => e.CakeId == cakeId && e.OwnerId == _userId);

                ctx.ActiveCakes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}