using AutoMapper;
using CrudCliente.api.Domain.Entities;
using CrudCliente.api.UI.DTOs;

namespace CrudCliente.api.Application.Implementation.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoClienteDTO, Cliente>()
                .ForMember(x => x.Create_at, x => x.MapFrom(x => DateTime.Now));
        }
    }
}
