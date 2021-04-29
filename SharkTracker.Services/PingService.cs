using SharkTracker.Data;
using SharkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Services
{
    public class PingService
    {
        private readonly Guid _userId;
        public PingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePing(PingCreate model)
        {
            var entity = new Ping()
            {
                OwnerId = _userId,
               
                PingLocation = model.PingLocation,
                SharkTagId = model.SharkTagId,
                PingDate = model.PingDate
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ping.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PingListItem> GetPings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ping.Where(e => e.OwnerId == _userId)
                    .Select(e => new PingListItem
                    {
                        PingId = e.PingId,
                        PingDate = e.PingDate,
                        PingLocation = e.PingLocation,
                        SharkTagId = e.SharkTagId,
                        
                    });
                return query.ToArray();
            }
        }

        public PingDetail GetPingById(int id)
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var entity = ctx.Ping.Single(e => e.PingId == id && e.OwnerId == _userId);
                return
                    new PingDetail
                    {
                        PingId = entity.PingId,
                        PingDate = entity.PingDate,
                        PingLocation = entity.PingLocation,
                        SharkTagId = entity.SharkTagId,
                        
                    };
            }
        }

        public PingDetail GetPingByPingLocation(string location)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var locations = from l in ctx.Ping select l;
                
                var entity = ctx.Ping.Single(e => e.PingLocation == location && e.OwnerId == _userId );
                if (!string.IsNullOrWhiteSpace(location))
                {
                    locations = locations.Where(s => s.PingLocation.Contains(location));
                }
               
                return
                    new PingDetail
                    {
                        PingId = entity.PingId,
                        PingDate = entity.PingDate,
                        PingLocation = entity.PingLocation,
                        SharkTagId = entity.SharkTagId,

                    };
            }
        }

        public PingDetail GetPingBySharkTagId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ping.Single(e => e.SharkTagId == id && e.OwnerId == _userId);
                return
                    new PingDetail
                    {
                        PingId = entity.PingId,
                        PingDate = entity.PingDate,
                        PingLocation = entity.PingLocation,
                        SharkTagId = entity.SharkTagId,

                    };
            }
        }

        public bool UpdatePing(PingEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ping.Single(e => e.PingId == model.PingId && e.OwnerId == _userId);
                entity.PingDate = model.PingDate;
                entity.PingLocation = model.PingLocation;
                entity.SharkTagId = model.SharkTagId;
               
                return ctx.SaveChanges() == 1;  
            }
        }

        public bool DeletePing(int PingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ping.Single(e => e.PingId == PingId && e.OwnerId == _userId);
                ctx.Ping.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
