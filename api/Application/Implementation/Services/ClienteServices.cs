using CrudCliente.api.Application.Implementation.Interface;
using CrudCliente.api.Domain.Entities;
using CrudCliente.api.Infrastructure.Database.Repositories;

namespace CrudCliente.api.Application.Implementation.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAsync()
        {
            return await clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await clienteRepository.GetClienteByIdAsync(id);
        }

        public async Task<Cliente> InsertAsync(Cliente cliente)
        {
            return await clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            return await clienteRepository.UpdateClienteAsync(cliente);
        }
        public async Task DeleteAsync(int id)
        {
            await clienteRepository.DeleteClienteAsync(id);
        }
    }
}
