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
                
                TagManufacturer = model.TagManufacturer,
                TagModel = model.TagModel,
                TagSerialNumber=model.TagSerialNumber
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tag.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TagListItem> GetTags()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tag.Where(e => e.OwnerId == _userId)
                    .Select(e => new TagListItem
                    {
                        TagId = e.TagId,
                        TagManufacturer = e.TagManufacturer,
                        TagSerialNumber = e.TagSerialNumber,
                       TagModel=e.TagModel
                    });
                return query.ToArray();
            }

           
        }

        public TagDetail GetTagById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tag.Single(e => e.TagId == id && e.OwnerId == _userId);

                return
                    new TagDetail
                    {
                        TagId = entity.TagId,
                        TagManufacturer = entity.TagManufacturer,
                        TagModel = entity.TagModel,
                        TagSerialNumber=entity.TagSerialNumber
                    };

            }
        }

        public bool UpdateTag(TagEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tag.Single(e => e.TagId == model.TagId && e.OwnerId == _userId);
                entity.TagId = model.TagId;
                entity.TagManufacturer = model.TagManufacturer;
                entity.TagModel = model.TagModel;
                entity.TagSerialNumber = model.TagSerialNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTag(int tagNumber)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tag.Single(e => e.TagId == tagNumber && e.OwnerId == _userId);

                ctx.Tag.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
