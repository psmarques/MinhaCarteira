using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurarDataServices(services);
            ConfigureAuthentication(services);

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Carteiras");
                options.Conventions.AuthorizeFolder("/Operacoes");
                options.Conventions.AuthorizeFolder("/Api");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc();
        }

        private void ConfigurarDataServices(IServiceCollection services)
        {
            //Memoria
            services.AddScoped<IUsuarioData, Data.MemData.UsuarioMemData>();
            services.AddScoped<ICarteiraData, Data.MemData.CarteiraMemData>();
            services.AddScoped<IOperacaoData, Data.MemData.OperacaoMemData>();

            //SQLite
            //services.AddScoped<IUsuarioData, UsuarioData>();
            //services.AddScoped<ICarteiraData, CarteiraData>();
            //services.AddScoped<IOperacaoData, OperacaoData>();

            services.AddDbContextPool<MinhaCarteiraDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString(Core.Util.Config.ConnectionStringName));
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions =>
            {
                cookieOptions.LoginPath = Core.Util.Pages.LoginSignIn;
            });
        }


    }
}
