using AutoMapper;
using ShrtLy.BLL.Modules.Shortening.Dtos;
using ShrtLy.DAL.Entitites;

namespace ShrtLy.BLL.Modules.Shortening
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<LinkEntity, LinkDto>().ReverseMap();
        }
    }
}
