using AutoMapper;
using Gighub.DTO;
using Gighub.Models;
namespace Gighub
{
    public class AutoMapperProfile : Profile
    {
        // to enable the automapper we add  to the our query
        // .ProjectTo<NotificationDTO>()//use Automapper.QueryableExtension namespace to link
        // and to Global.asax we add  AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Genre,GenreDto>();
            CreateMap<GIg, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}