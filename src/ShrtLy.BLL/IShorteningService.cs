using System.Collections.Generic;

namespace ShrtLy.BLL
{
    public interface IShorteningService
    {
        IEnumerable<LinkDto> GetShortLinks();
        string ProcessLink(string url);
    }
}