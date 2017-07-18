using AutoMapper;
using Vidly.Dto;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Costumer, CostumerDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<CostumerDto, Costumer>();

            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}