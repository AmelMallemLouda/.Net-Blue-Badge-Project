using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Services
{
    public class VacationPackageService
    {
        private readonly Guid _userId;

        public VacationPackageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVacPac(VacationPackageCreate model)
        {
            var entity =
                new VacationPackage()
                {
                    OwnerId = _userId,
                    VacationPackageName = model.VacPacName,
                    Transportation = model.Transportation,
                    Price = model.Price,
                    HotelId = model.HotelId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.VacationPackage.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VacationPackageListItem> GetVacPacs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .VacationPackage
                    .Where(e => e.OwnerId == _userId)
                    .Select(e =>
                    new VacationPackageListItem
                    {
                        VacId = e.VacId,
                        VacPacName = e.VacationPackageName,
                    }
                    );

                return query.ToArray();
            }
        }

        public VacationPackageDetail GetVacPacsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .VacationPackage
                    .Single(e => e.VacId == id && e.OwnerId == _userId);
                return
                    new VacationPackageDetail
                    {
                        VacId = entity.VacId,
                        Flight = entity.Flight,
                        Food = entity.Food,
                        Price = entity.Price,
                        Transportation = entity.Transportation,
                        VacationPackageName = entity.VacationPackageName,
                        HotelId = entity.HotelId
                    };
            }
        }

        public bool UpdateVacPac(VacationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .VacationPackage
                    .Single(e => e.VacId == model.VacId && e.OwnerId == _userId);

                entity.VacationPackageName = model.VacationPackageName;
                entity.Price = model.Price;
                entity.Transportation = model.Transportation;
                entity.Flight = model.Flight;
                entity.Food = model.Food;
                entity.HotelId = model.HotelId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVacPac(int vacId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .VacationPackage
                    .Single(e => e.VacId == vacId && e.OwnerId == _userId);

                ctx.VacationPackage.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
