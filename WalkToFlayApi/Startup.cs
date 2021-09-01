using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
            services.AddSwaggerGen(c =>
            {
                // API ���
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Walk To Fly API",
                    //Description = "���쭸v1 API",
                    //TermsOfService = new Uri(""),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "",
                    //    Email = string.Empty,
                    //    Url = new Uri(""),
                    //}
                });

                // Ū�� XML �ɮײ��� API ����
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //Swagger �[�JJWT Token����
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            
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

            //JWT
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // �����ҥ��ѮɡA�^�����Y�|�]�t WWW-Authenticate ���Y�A�o�̷|��ܥ��Ѫ��Բӿ��~��]
                    options.IncludeErrorDetails = true; // �w�]�Ȭ� true�A���ɷ|�S�O����

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //// �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
                        //NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        //// �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����
                        //RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

                        // �@��ڭ̳��|���� Issuer
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JwtToken:Issuer"], // JwtToken.Secret ���ӱq IConfiguration ���o

                        // �Y�O��@���A���q�`���ӻݭn���� Audience
                        ValidateAudience = false,
                        //ValidAudience = "JwtAuthDemo", // ValidateAudience = false �����ҴN���ݭn��g

                        // �@��ڭ̳��|���� Token �����Ĵ���
                        ValidateLifetime = true,

                        // �p�G Token ���]�t key �~�ݭn���ҡA�@�볣�u��ñ���Ӥw
                        ValidateIssuerSigningKey = false,

                        // JwtToken.Secret ���ӱq IConfiguration ���o
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:Secret"]))
                    };
                });
            //FluentValidation
            services.AddFluentValidation(o =>
            {
                o.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
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
            //����
            app.UseAuthentication();
            //�v��
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WalkToFly API v1");
            });

            //SPA
            app.UseSpaStaticFiles();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp/Angular");
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = path;

                //�nBuild�~�ݭn
                //if (env.IsDevelopment())
                //{
                //    spa.UseReactDevelopmentServer(npmScript: "start");
                //}
            });
        }
    }
}
