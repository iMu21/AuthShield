using AuthShield.Application.Features.Auth.Query.GetAllUsers;
using AuthShield.Domain.Entities;
using AutoMapper;

namespace AuthShield.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserVm>();
        }
    }
}
