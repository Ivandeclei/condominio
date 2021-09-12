using AutoMapper;
using Condominio.Domain.Models;
using Condominio.WebApi.Dtos;

namespace Condominio.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<MoradiaCondominioDto, MoradiaCondominio>().ReverseMap();
            CreateMap<EnderecoBaseDto, EnderecoBase>().ReverseMap();
            CreateMap<EstadoDto, Estado>().ReverseMap();
            CreateMap<CondominioParametroGet, CondominioParametro>().ReverseMap();
        }
    }
}
