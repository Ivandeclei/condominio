using AutoMapper;
using Condominio.Domain.Models;
using Condomino.DbAdapter.Clients;

namespace Condomino.DbAdapter
{
    public class CondominioAdapterMapperProfile : Profile
    {
        public CondominioAdapterMapperProfile()
        {
            CreateMap<MoradiaCondominioDto, MoradiaCondominio>().ReverseMap();
            CreateMap<EnderecoBaseDto, EnderecoBase>().ReverseMap();
            CreateMap<EstadoDto, Estado>().ReverseMap();
        }
    }
}
