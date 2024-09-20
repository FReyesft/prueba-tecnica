using AutoMapper;
using Inmersys.Core.Dtos;
using Inmersys.Core.Models;
namespace AutoMapperDemo
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employees, EmployeeResponseDto>();
                cfg.CreateMap<CreateEmployeeRequestDto, Employees>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}