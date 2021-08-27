using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Infrastructure.ActionFilter;
using WalkToFlayApi.Infrastructure.DependencyInjection;
using WalkToFlayApi.Repository.Implement;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Implement;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi
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
            services.AddControllers(option=> {
                option.Filters.Add<SuccessMessageActionFilter>();
            });
            //swagger
            services.AddSwaggerGen();
            //API Version
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            //DependencyInjection
            services.AddCommon();
            services.AddApplication();
            services.AddService();
            services.AddRepository();

            //SPA
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/Angular";
            });

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //SPA
            app.UseSpaStaticFiles();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp/Angular");
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = path;

                //要Build才需要
                //if (env.IsDevelopment())
                //{
                //    spa.UseReactDevelopmentServer(npmScript: "start");
                //}
            });
        }
    }
}
