using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using SampleCoreWebApi.ResponseWrapping;

namespace SampleCoreWebApi.StartupExtensions
{
    public static class AppBuilderExtension
    {
        public static void UseAllRequiredServices(this IApplicationBuilder app)
        {
            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            #endregion

            //Support local static file like css js etc
            app.UseStaticFiles();

            //Support JWT Authentication
            app.UseAuthentication();

            //Global Response for all API
            //app.UseResponseWrapper();

            //Support MVC
            app.UseMvc();

            //Support for ResponseCompression
            // app.UseResponseCompression();


        }
    }
}
