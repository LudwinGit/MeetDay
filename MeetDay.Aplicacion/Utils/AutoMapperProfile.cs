using AutoMapper;
using MeetDay.Dominio.Core.Dtos.Management;
using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Management, ManagementDto>();
            CreateMap<ManagementDto, Management>();
        }
    }
}