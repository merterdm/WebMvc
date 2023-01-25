using AutoMapper;
using CoreMvc.Entities;
using CoreMvc.Models.EmployeeDTO;
using CoreMvc.Models.ProductDtos;

namespace CoreMvc.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<EmployeeInsertDTO, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
            CreateMap<Product, ProductIndexDto>();



        }
    }
}
