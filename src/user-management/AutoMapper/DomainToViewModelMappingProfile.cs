using AutoMapper;
using System.Collections.Generic;
using UserManagement.Domain.Entities;
using UserManagement.ViewModels;

namespace UserManagement.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(v => v.Id, d => d.MapFrom(t => t.Id))
                .ForMember(v => v.Name, d => d.MapFrom(t => t.Name))
                .ForMember(v => v.Cpf, d => d.MapFrom(t => t.Cpf))
                .ForMember(v => v.Email, d => d.MapFrom(t => t.Email))
                .ForMember(v => v.BirthDate, d => d.MapFrom(t => t.BirthDate))
                .ForMember(v => v.Genre, d => d.MapFrom(t => t.Genre))
                .ForMember(v => v.Active, d => d.MapFrom(t => t.Active));

            CreateMap<List<User>, List<UserViewModel>>();
        }
    }
}
