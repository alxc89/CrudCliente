using CrudCliente.api.Application.Implementation.Interface;
using CrudCliente.api.Application.Implementation.Mappings;
using CrudCliente.api.Application.Implementation.Services;
using CrudCliente.api.Infrastructure.Database.Context;
using CrudCliente.api.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlite("Data source=crudCliente.db");
});
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(NovoClienteMappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
