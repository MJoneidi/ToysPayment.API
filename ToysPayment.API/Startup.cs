using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using ToysPayment.API.Application;
using ToysPayment.API.Infrastructure;
using ToysPayment.API.Infrastructure.Data;

namespace ToysPayment.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToysPayment.API", Version = "v1" });
            });
            services.AddApplicationServices(Configuration);
            services.AddInfrastructureServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToysPayment.API v1"));
            }
            GenerateDB(app);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void GenerateDB(IApplicationBuilder app)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetService<CustomerDbContext>())
                    {
                        context.Database.EnsureCreated();

                        context.Customers.Add(new Models.Entities.Customer()
                        {
                            FirstName = "Moh",
                            LastName = "Jon",
                            Points = 0,
                            TotalBuy = 0
                        });
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: handle 
                throw;
            }
        }
    }
}
