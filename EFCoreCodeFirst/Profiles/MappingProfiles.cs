using AutoMapper;
using EFCoreCodeFirst.Models;
using EFCoreCodeFirst.Models.Entities;

namespace EFCoreCodeFirst.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
