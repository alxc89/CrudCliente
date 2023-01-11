using CrudCliente.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudCliente.api.Infrastructure.Database.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
