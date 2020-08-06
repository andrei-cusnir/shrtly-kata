using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShrtLy.DAL
{
    public class LinksRepository : ILinksRepository
    {
        private readonly ShrtLyContext context;

        public LinksRepository(ShrtLyContext context)
        {
            this.context = context;
        }

        public int CreateLink(LinkEntity entity)
        {
            this.context.Add(entity);
            this.context.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<LinkEntity> GetAllLinks()
        {
            return this.context.Links;
        }
    }
}
