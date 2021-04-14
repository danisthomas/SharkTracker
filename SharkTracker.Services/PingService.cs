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
                PingId = model.PingId,
                PingDateTime = model.PingDateTime,
                PingLocation = model.PingLocation,
                SharkId = model.SharkId,
                TagNumber = model.TagNumber
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PingListItem> GetPings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Pings.Where(e => e.OwnerId == _userId)
                    .Select(e => new PingListItem
                    {
                        PingId = e.PingId,
                        PingDateTime = e.PingDateTime,
                        PingLocation = e.PingLocation,
                        SharkId = e.SharkId,
                        TagNumber = e.TagNumber
                    });
                return query.ToArray();
            }
        }

        public PingDetail GetPingById(int id)
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var entity = ctx.Pings.Single(e => e.PingId == id && e.OwnerId == _userId);
                return
                    new PingDetail
                    {
                        PingId = entity.PingId,
                        PingDateTime = entity.PingDateTime,
                        PingLocation = entity.PingLocation,
                        SharkId = entity.SharkId,
                        TagNumber = entity.TagNumber
                    };
            }
        }

        public bool UpdatePing(PingEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Pings.Single(e => e.PingId == model.PingId && e.OwnerId == _userId);
                entity.PingDateTime = model.PingDateTime;
                entity.PingLocation = model.PingLocation;
                entity.SharkId = model.SharkId;
                entity.TagNumber = model.TagNumber;

                return ctx.SaveChanges() == 1;  
            }
        }

        public bool DeletePing(int PingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Pings.Single(e => e.PingId == PingId && e.OwnerId == _userId);
                ctx.Pings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
