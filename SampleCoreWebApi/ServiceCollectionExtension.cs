using System;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
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
    public static class ServiceCollectionExtension
    {
        public static void AddAllServices(this IServiceCollection services)
        {
            #region  Repo

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPoliticalRepository, PoliticalRepository>();

            #endregion

            #region AutoMapper

            services.AddAutoMapper();

            #endregion

            #region MVC

            //Enable MVC Middleware
            services.AddMvc();

            #endregion

            #region Swagger

            //Enable Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            #endregion


        }

        //public static void AddResponseCompressionWithSettings(this IServiceCollection services)
        //{
        //    services.AddResponseCompression(options =>
        //    {
        //        options.Providers.Add<GzipCompressionProvider>();
        //        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
        //    });

        //    services.Configure<GzipCompressionProviderOptions>(options =>
        //    {
        //        options.Level = CompressionLevel.Fastest;
        //    });
        //}
    }
}
