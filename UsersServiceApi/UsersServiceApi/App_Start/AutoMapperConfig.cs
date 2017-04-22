using AutoMapper;
using DataLayer.Models;
using DTO;

namespace UsersServiceApi
{
    public static class AutoMapperConfig
    {
        public static IConfigurationProvider Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, User>().ForMember(dest => dest.Id, opts => opts.Ignore());
                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<CompanyEntity, Company>().ForMember(dest => dest.Id, opts => opts.Ignore());
                cfg.CreateMap<Company, CompanyEntity>();
            });
        }
    }
}