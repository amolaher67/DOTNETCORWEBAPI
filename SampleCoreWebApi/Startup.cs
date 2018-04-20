using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleCoreWebApi.DataModel;
using SampleCoreWebApi.DataModel.Models;
using SampleCoreWebApi.LogProvider;
using SampleCoreWebApi.StartupExtensions;

namespace SampleCoreWebApi
{
    //Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
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
            #region 1. DBContext

            //Read Connection String
            var connection = Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Configuration.GetConnectionString(\"DefaultConnection\")");
            //Inject DataContext class here
            services.AddDbContext<ElectionContext>(options => options.UseSqlServer(connection));

            #endregion

            #region 2 .JWT Bearer Authentication

            services.AddJwtAuthentication(Configuration);

            #endregion

            #region  3. Extension method to include All repositories

            services.AddAllServices();

            #endregion

            #region 4. ResponseCompression
            //services.AddResponseCompressionWithSettings();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            #region 1. Read Connection String and configure LOggerFactory
            var connection = Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Configuration.GetConnectionString(\"DefaultConnection\")");

            // loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            // loggerFactory.AddDebug();
            loggerFactory.AddContext(LogLevel.Error, connection);
            #endregion

            #region 2 Exception Logging 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            #endregion

            //Extension method to load all required middleweare
            app.UseAllRequiredServices();

        }
    }
}
