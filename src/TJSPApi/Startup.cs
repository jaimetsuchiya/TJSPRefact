using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SGDAU.Seguranca.Domain;

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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddScoped<IDatabaseCommandCommit, DatabaseCommandCommit>();
            services.AddScoped<ISegurancaRepository, SegurancaRepository>();
            services.AddScoped<ISegurancaService, SegurancaService>();

            var audiences = this.Configuration.GetSection("Authentication:Audiences").Get<string[]>();
            var key = Encoding.ASCII.GetBytes(this.Configuration.GetSection("Authentication:SecretKey").Value);
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = audiences.Any(),
                    ValidAudiences = audiences
                };
            });

            //services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            //services.AddScoped<IUnidadeService, UnidadeService>();
            //services.AddScoped<IUnidadeQuery, UnidadeQuery>();

            //services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
            //services.AddScoped<IAdvogadoService, AdvogadoService>();
            //services.AddScoped<IAdvogadoQuery, AdvogadoQuery>();

            //this.QueryPartTypesToRegister.Add(typeof(IAdvogadoQuery));
            //this.QueryPartTypesToRegister.Add(typeof(IUnidadeQuery));

            foreach ( string assemblyName in GetAssemblies() )
            {
                var a = Assembly.Load(assemblyName);
                var types = a.GetTypes();
                for (var t = 0; t < types.Length; t++)
                {
                    if (types[t].IsInterface && (types[t].Name.EndsWith("Query") || types[t].Name.EndsWith("Repository") || types[t].Name.EndsWith("Service")))
                    {
                        var interfaceType = types[t];
                        var implementationType = types.FirstOrDefault(t => t.GetInterfaces().Contains(interfaceType));
                        services.Add(new ServiceDescriptor(interfaceType, implementationType, ServiceLifetime.Scoped));

                        if (types[t].Name.EndsWith("Query"))
                            this.QueryPartTypesToRegister.Add(interfaceType);
                    }
                }
            }

            services.AddSingleton<IGraphQLSchemaCollection>(new GraphQLSchemaCollection(this.QueryPartTypesToRegister));
        }

        private string[] GetAssemblies()
        {
            var result = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var exclusion = new string[] { "Seguranca", "Parametros" };
            var files = new DirectoryInfo(path).GetFiles("SGDAU.*.Domain.dll");
            if( files != null && files.Length > 0 )
            {
                foreach(var file in files)
                {
                    bool add = true;
                    for(var i=0; i < exclusion.Length; i++)
                    {
                        if (file.FullName.Contains(exclusion[i]))
                        {
                            add = false;
                            break;
                        }
                    }
                    if(add)
                        result.Add(Assembly.LoadFile(file.FullName).GetName().Name);
                }
                    
            }
            return result.ToArray();
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

            app.UseAuthentication();
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
