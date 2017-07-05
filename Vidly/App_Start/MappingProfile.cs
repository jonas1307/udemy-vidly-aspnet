using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Costumer, CostumerDto>();
            Mapper.CreateMap<CostumerDto, Costumer>();
        }
    }
}