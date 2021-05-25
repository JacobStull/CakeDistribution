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
                    CakeName = model.CakeName,
                    CakeIcing = model.CakeIcing,
                    Description = model.Description

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cakes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CakeListItem> GetCakes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cakes
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
    }
}
