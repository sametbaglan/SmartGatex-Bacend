using AutoMapper;
using SmartGatex.DataAccess.Dtos;
using SmartGatex.Entity.Concrete;

namespace SmartGatex.DataAccess.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Cams, CamsDto>().ReverseMap();
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<LicencePlates, LicencePlatesDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
        }
    }
}
