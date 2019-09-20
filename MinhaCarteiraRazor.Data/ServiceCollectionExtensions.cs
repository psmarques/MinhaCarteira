using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Data
{
    public static class ServiceCollectionExtensions
    {

        public static void AddDataAccessServices(this IServiceCollection services, string connString)
        {
            //Memoria
            services.AddSingleton<IUsuarioData, MemData.UsuarioMemData>();
            services.AddSingleton<ICarteiraData, MemData.CarteiraMemData>();
            services.AddSingleton<IOperacaoData, MemData.OperacaoMemData>();

            //SQLite
            //services.AddScoped<IUsuarioData, UsuarioData>();
            //services.AddScoped<ICarteiraData, CarteiraData>();
            //services.AddScoped<IOperacaoData, OperacaoData>();

            //services.AddDbContextPool<MinhaCarteiraDbContext>(options =>
            //{
            //    options.UseSqlite(connString);
            //});
        }
    }
}
