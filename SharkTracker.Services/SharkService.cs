using SharkTracker.Data;
using SharkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Services
{
    public class SharkService
    {
        private readonly Guid _userId;
        public SharkService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShark(SharkCreate model)
        {
            var entity = new Shark()
            {
                OwnerId = _userId,
                SharkName = model.SharkName,
                Species = model.Species,
                Length = model.Length,
                Sex = model.Sex,
                Weight = model.Weight,
                Age = model.Age

            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Sharks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SharkListItem> GetSharks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Sharks.Where(e => e.OwnerId == _userId)
                    .Select(e => new SharkListItem
                    {
                       SharkId = e.SharkId,
                        SharkName = e.SharkName,
                        Species = e.Species,
                        Length = e.Length,
                        Sex = e.Sex,
                        Weight = e.Weight,
                        Age = e.Age,
                    });;
                return query.ToArray();
            }
        }

        public SharkDetail GetSharkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sharks.Single(e => e.SharkId == id && e.OwnerId == _userId);

                return
                    new SharkDetail
                    {
                        SharkId = entity.SharkId,
                        SharkName = entity.SharkName,
                        Species = entity.Species,
                        Length = entity.Length,
                        Sex = entity.Sex,
                        Weight = entity.Weight,
                        Age = entity.Age
                    };
            }
        }

        public bool UpdateShark(SharkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sharks.Single(e => e.SharkId == model.SharkId && e.OwnerId == _userId);

                entity.SharkName = model.SharkName;
                entity.Species = model.Species;
                entity.Length = model.Length;
                entity.Sex = model.Sex;
                entity.Weight = model.Weight;
                entity.Age = model.Age;

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
