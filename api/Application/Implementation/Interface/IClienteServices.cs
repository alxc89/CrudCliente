using CrudCliente.api.Domain.Entities;

namespace CrudCliente.api.Application.Implementation.Interface
{
    public interface IClienteServices
    {
        Task<IEnumerable<Cliente>> GetAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> InsertAsync(Cliente cliente);
        Task<Cliente> UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
