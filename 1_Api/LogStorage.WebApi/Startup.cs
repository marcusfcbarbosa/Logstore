using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Handlers;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Logstore.Infra.Repositorys;
using LogStorage.WebApi.InfraEstructure;

namespace LogStorage.WebApi
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
            services.AddDbContext<LogStoreContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            registrandoDependencias(services);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            DocumentacaoApi(services);
        }
        public void DocumentacaoApi(IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Docs", Version = "v1" });

            });
            services.AddSwaggerDocumentation();

        }
        public void registrandoDependencias(IServiceCollection services)
        {

            #region"Contexto"
            services.AddScoped<LogStoreContext, LogStoreContext>();
            #endregion

            #region"Handlers"
            services.AddScoped<ClienteHandler, ClienteHandler>();
            services.AddScoped<ProdutoHandler, ProdutoHandler>();
            services.AddScoped<PedidoHandler, PedidoHandler>();
            #endregion

            #region"Repositórios"
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
            });


            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}