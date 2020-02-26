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
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Data;

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
        readonly string MyAllowSpecificOrigins = "CorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .WithOrigins(this.Configuration.GetSection("Authentication:Origins").Get<string[]>())
                     .SetIsOriginAllowedToAllowWildcardSubdomains();
                });
            });

            services.AddMemoryCache();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(this.Configuration);

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
                    ValidateAudience = true,
                    ValidAudiences = audiences
                };
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDbConnection>(provider =>
                (IDbConnection)new SqlConnection(Configuration.GetSection("ConnectionStrings:REFIConnectionString").Value)
            );
            services.AddScoped<IDatabaseQueryCommand, DatabaseQueryCommand>();
            services.AddScoped<IDatabaseCommandCommit, DatabaseCommandCommit>();
            services.AddScoped<ISegurancaRepository, SegurancaRepository>();
            services.AddScoped<ISegurancaService, SegurancaService>();
            services.AddScoped<IContextIronMountain>(provider =>
                new ContextIronMountain(
                    this.Configuration,
                    provider.GetService<IHttpContextAccessor>().HttpContext.User
                )
            );

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
            var exclusion = this.Configuration.GetSection("GraphQL:ExclusionDomainList").Get<string[]>();
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
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .WithOrigins(this.Configuration.GetSection("Authentication:Origins").Get<string[]>())
                       .SetIsOriginAllowedToAllowWildcardSubdomains();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("CorsPolicy");
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
