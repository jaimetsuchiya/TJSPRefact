using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SGDAU.Advogado.Domain;
using SGDAU.Repository.Infrastructure;
using SGDAU.Unidade.Domain;

namespace TJSPApi
{
    public class Startup
    {
        public List<Type> TypesToRegister { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //TypesToRegister = Assembly.Load("SGDAU.Advogado.Domain")
            //                         .GetTypes()
            //                         .Where(x => !string.IsNullOrEmpty(x.Namespace))
            //                         .Where(x => x.IsClass)
            //                         .Where(x => x.Namespace.StartsWith("SGDAU."))
            //                         .Where(x => x.Namespace.EndsWith(".Domain")).ToList();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddScoped<IDatabaseCommandCommit, DatabaseCommandCommit>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<IAdvogadoService, AdvogadoService>();
            services.AddScoped<IAdvogadoQuery, AdvogadoQuery>();
            services.AddScoped<IUnidadeQuery, UnidadeQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
