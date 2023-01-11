using CrudCliente.api.Domain.Entities;
using CrudCliente.api.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace CrudCliente.api.Infrastructure.Database.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;
        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await context
                    .Clientes
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await context
                    .Clientes
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await context.Clientes.FindAsync(cliente.Id);
            if (clienteConsultado == null)
            {
                return null;
            }

            context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            await context.SaveChangesAsync();
            return clienteConsultado;
        }

        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsultado = await context.Clientes.FindAsync(id);
            context.Clientes.Remove(clienteConsultado);
            await context.SaveChangesAsync();
        }
    }
}
