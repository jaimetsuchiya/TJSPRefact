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
using SGDAU.Common;
using SGDAU.Repository.Infrastructure;
using SGDAU.Unidade.Domain;

namespace TJSPApi
{
    public class Startup
    {
        public List<Type> QueryPartTypesToRegister { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            QueryPartTypesToRegister = new List<Type>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddScoped<IDatabaseCommandCommit, DatabaseCommandCommit>();

            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<IUnidadeQuery, UnidadeQuery>();

            services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
            services.AddScoped<IAdvogadoService, AdvogadoService>();
            services.AddScoped<IAdvogadoQuery, AdvogadoQuery>();

            this.QueryPartTypesToRegister.Add(typeof(IAdvogadoQuery));
            this.QueryPartTypesToRegister.Add(typeof(IUnidadeQuery));

            //foreach ( string assemblyName in GetAssemblies() )
            //{
            //    var a = Assembly.Load(assemblyName);
            //    var types = a.GetTypes();
            //    for (var t = 0; t < types.Length; t++)
            //    {
            //        if (types[t].IsInterface && (types[t].Name.EndsWith("Query") || types[t].Name.EndsWith("Repository") || types[t].Name.EndsWith("Service")))
            //        {
            //            var interfaceType = types[t];
            //            var implementationType = types.FirstOrDefault(t => t.GetInterfaces().Contains(interfaceType));
            //            services.Add(new ServiceDescriptor(interfaceType, implementationType, ServiceLifetime.Scoped));

            //            if (types[t].Name.EndsWith("Query"))
            //                this.QueryPartTypesToRegister.Add(interfaceType);
            //        }
            //    }
            //}

            services.AddSingleton<IGraphQLSchemaCollection>(new GraphQLSchemaCollection(this.QueryPartTypesToRegister));
        }

        private string[] GetAssemblies()
        {
            var references = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(x => x.Name).ToList();
                references.AddRange(AppDomain.CurrentDomain.GetAssemblies().Select(x => x.GetName().Name).ToList());
                references.AddRange(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(x => x.Name).ToList());
                references.AddRange(Assembly.GetCallingAssembly().GetReferencedAssemblies().Select(x => x.Name).ToList());

            return references.Where(x => x.Contains("SGDAU.") && x.Contains(".Domain")).Distinct().ToArray();
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
    public interface IGraphQLSchemaCollection
    { 
        List<Type> Items { get; }
    }

    public class GraphQLSchemaCollection: IGraphQLSchemaCollection
    {
        public GraphQLSchemaCollection(List<Type> parts)
        {
            this.Items = parts; 
        }

        public List<Type> Items { get; }
    }

}
