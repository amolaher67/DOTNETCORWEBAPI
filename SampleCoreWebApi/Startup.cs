using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleCoreWebApi.BusinessLayer.IRepositories;
using SampleCoreWebApi.BusinessLayer.Repositories;
using SampleCoreWebApi.DataModel.Models;
using SampleCoreWebApi.DataModel.UOWGenericRepo;
using Swashbuckle.AspNetCore.Swagger;

namespace SampleCoreWebApi
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
            #region DBContext

            //Read Connection String
            var connection = Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Configuration.GetConnectionString(\"DefaultConnection\")");
            //Inject DataContext class here
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            #endregion

            //Extension method to include All repositories
            services.AddAllServices();


            //services.AddResponseCompressionWithSettings();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
         

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();
            app.UseMvc();

            // app.UseResponseCompression();
            //  app.UseResponseWrapper();

        }
    }
}
