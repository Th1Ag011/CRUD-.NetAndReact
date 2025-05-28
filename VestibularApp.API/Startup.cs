using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VestibularApp.Application.Services;
using VestibularApp.Application.Services.Interfaces;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Infrastructure.Data;
using VestibularApp.Infrastructure.Repository;

namespace VestibularApp.API
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VestibularApp.API", Version = "v1" });
            });

            services.AddDbContext<VestibularContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("Connection"))); 

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IInscricaoRepository, InscricaoRepository>();
            services.AddScoped<IProcessoSeletivoRepository, ProcessoSeletivoRepository>();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IInscricaoService, InscricaoService>();
            services.AddScoped<IProcessoSeletivoService, ProcessoSeletivoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VestibularApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
