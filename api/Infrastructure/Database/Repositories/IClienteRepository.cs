using CrudCliente.api.Domain.Entities;

namespace CrudCliente.api.Infrastructure.Database.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}
