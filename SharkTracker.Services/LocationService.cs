using SharkTracker.Data;
using SharkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public LocationService()
        {
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                OwnerId = _userId,
                TaggingLocation = model.TaggingLocation
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Location.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Location.Where(e => e.OwnerId == _userId)
                    .Select(e => new LocationListItem
                    {
                        LocationId = e.LocationId,
                        TaggingLocation = e.TaggingLocation

                    });
                return query.ToArray();
            }
        }
        public IEnumerable<Location> GetLocationsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Location.ToList();
            }
        }

        

        public LocationDetail GetLocationsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Location.Single(e => e.LocationId == id && e.OwnerId == _userId);
                return
                    new LocationDetail
                    {
                        LocationId = entity.LocationId,
                        TaggingLocation = entity.TaggingLocation

                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Location.Single(e => e.LocationId == model.LocationId && e.OwnerId == _userId);
                entity.TaggingLocation = model.TaggingLocation;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Location.Single(e => e.LocationId == locationId && e.OwnerId == _userId);
                ctx.Location.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }


}

