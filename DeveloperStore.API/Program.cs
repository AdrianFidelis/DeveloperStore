using DeveloperStore.Application.Interfaces;
using DeveloperStore.Infrastructure.Data;
using DeveloperStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuração do EF Core com SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Injeção de dependência do SaleService
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();

            var app = builder.Build();

            // Pipeline de requisições
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
