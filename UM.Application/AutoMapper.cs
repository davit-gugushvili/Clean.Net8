using UM.Application.Features.Users.Queries;
using UM.Domain.Aggregates.User;

namespace UM.Application
{
    public sealed class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDto>().ForMember(desc => desc.Role, x => x.MapFrom(src => src.Role!.Name));
        }
    }
}
