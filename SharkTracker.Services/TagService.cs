using SharkTracker.Data;
using SharkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Services
{
    

    public class TagService
    {
        private readonly Guid _userId;
        public TagService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTag(TagCreate model)
        {
            var entity = new Tag()
            {
                OwnerId = _userId,
                TagNumber = model.TagNumber,
                TagLocation = model.TagLocation,
                TagDate = model.TagDate,
                SharkId = model.SharkId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tags.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TagListItem> GetTags()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tags.Where(e => e.OwnerId == _userId)
                    .Select(e => new TagListItem
                    {
                        TagNumber = e.TagNumber,
                        TagLocation = e.TagLocation,
                        TagDate = e.TagDate,
                        SharkId = e.SharkId
                    });
                return query.ToArray();
            }

           
        }

        public TagDetail GetTagById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tags.Single(e => e.TagNumber == id && e.OwnerId == _userId);

                return
                    new TagDetail
                    {
                        TagNumber = entity.TagNumber,
                        TagDate = entity.TagDate,
                        TagLocation = entity.TagLocation,
                        SharkId = entity.SharkId
                    };

            }
        }

        public bool UpdateTag(TagEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tags.Single(e => e.TagNumber == model.TagNumber && e.OwnerId == _userId);
                entity.TagNumber = model.TagNumber;
                entity.TagLocation = model.TagLocation;
                entity.TagDate = model.TagDate;
                entity.SharkId = model.SharkId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTag(int tagNumber)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tags.Single(e => e.TagNumber == tagNumber && e.OwnerId == _userId);

                ctx.Tags.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
