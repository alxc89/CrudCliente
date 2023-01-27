using AutoMapper;
using CrudCliente.api.Domain.Entities;
using CrudCliente.api.UI.DTOs;

namespace CrudCliente.api.Application.Implementation.Mappings
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraClienteDTO, Cliente>()
                .ForMember(x => x.Update_at, x => x.MapFrom(x => DateTime.Now));
        }
    }
}
