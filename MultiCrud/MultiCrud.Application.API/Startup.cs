using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiCrud.Application.Abstractions.Services;
using MultiCrud.Application.MapperConfig;
using MultiCrud.Application.Services;
using MultiCrud.Domain.Abstractions.Repositories;
using MultiCrud.Domain.Abstractions.Services;
using MultiCrud.Domain.Services;
using MultiCrud.Infrastructure.Repository.Contexts;
using MultiCrud.Infrastructure.Repository.Repositories;

namespace MultiCrud.Application.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });
            services.AddScoped<IPersonApplicationService, PersonApplicationService>();
            services.AddScoped<IPersonEntityRepository, PersonEntityRepository>();
            services.AddScoped<IPersonDomainService, PersonDomainService>();
            services.AddScoped(typeof(IApplicationServiceBase<,,>), typeof(ApplicationServiceBase<,,>));
            services.AddScoped(typeof(IDomainServiceBase<>), typeof(DomainServiceBase<>));
            services.AddScoped(typeof(IEntityRepositoryBase<>), typeof(EntityRepositoryBase<>));

            services.AddDbContext<MultiCrudContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(DomainToOutputProfile), typeof(InputToDomainProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
