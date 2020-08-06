using System.Collections.Generic;

namespace ShrtLy.DAL
{
    public interface ILinksRepository
    {
        int CreateLink(LinkEntity entity);
        IEnumerable<LinkEntity> GetAllLinks();
    }
}