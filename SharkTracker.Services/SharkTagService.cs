using SharkTracker.Data;
using SharkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Services
{
    public class SharkTagService
    {
        private readonly Guid _userId;

        public SharkTagService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSharkTag(SharkTagCreate model)
        {
            var entity = new SharkTag()
            {
                OwnerId = _userId,
               
                StartDate = model.StartDate,
                SharkId = model.SharkId,
                TagId = model.TagId,
                LocationId = model.LocationId

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SharkTag.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<SharkTagListItem> GetSharkTags()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.SharkTag.Where(e => e.OwnerId == _userId)
                    .Select(e => new SharkTagListItem
                    {
                        SharkTagId=e.SharkTagId,
                        SharkId=e.SharkId,
                        SharkName=e.shark.SharkName,
                        Species=e.shark.Species,
                        Sex=e.shark.Sex,
                        Length=e.shark.Length,
                        Weight=e.shark.Weight,
                        Age=e.shark.Age,
                        TagId=e.tag.TagId,
                        TagSerialNumber=e.tag.TagSerialNumber,
                        TaggingLocation=e.location.TaggingLocation,
                        LocationId=e.LocationId,
                        StartDate=e.StartDate,
                        EndDate=e.EndDate
                    });

                return query.ToArray();
            }
        }
        public IEnumerable<SharkTag> GetSharkTagsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.SharkTag.ToList();
            }
        }
        public SharkTagDetail GetSharkTagById(int id)
        {
           using(var ctx = new ApplicationDbContext())
           {
                var entity = ctx.SharkTag.Single(e => e.SharkTagId == id && e.OwnerId == _userId);
                return new SharkTagDetail
                {
                    SharkTagId = entity.SharkTagId,
                    SharkId = entity.SharkId,
                    SharkName = entity.shark.SharkName,
                    TagId = entity.TagId,
                    TagSerialNumber = entity.tag.TagSerialNumber,
                    LocationId = entity.LocationId,
                    TaggingLocation = entity.location.TaggingLocation,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate

                };

           }
         }

        public bool UpdateSharkTag(SharkTagEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SharkTag.Single(e => e.SharkTagId == model.SharkTagId && e.OwnerId == _userId);
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.SharkId = model.SharkId;
                entity.LocationId = model.LocationId;
                entity.TagId = model.TagId;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteSharkTag(int SharkTagId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SharkTag.Single(e => e.SharkTagId == SharkTagId && e.OwnerId == _userId);
                ctx.SharkTag.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
