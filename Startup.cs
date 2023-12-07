using CovidWebService.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidWebService
{
    public class Startup
    {
        /// <summary>
        /// Accept data from files
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //JWT
            //Definir o protocolo de Autenticação
            var tokenKey = Configuration["Jwt:Key"];        //definida em appsettings.json
            var key = Encoding.ASCII.GetBytes(tokenKey);    //codifica string

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //2º - Configurar JwtBearer - Valida JWT recebido no Header
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    //options.Audience = "https://localhost:44348/";
                    //options.Authority = "https://localhost:44348/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            //Registar a classe que gere JWT   
            services.AddSingleton<IJWTAuthManager>(new JWTAuthManager(tokenKey));


            #region Swagger
            services.AddSwaggerDocument(o =>
                o.PostProcess = document =>
                {
                    document.Info.Title = "Core API";
                    document.Info.Version = "v1";
                    document.Info.Description = "Restful API for covid occurrences";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Francisco Arantes",
                        Email = "23504@alunos.ipca.pt",
                        Url = "https://www.ipca.pt"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under IPCA rights",
                        Url = "https://www.ipca.pt/license"
                    };
                }
                );
            #endregion

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http, //não usa o Bearer
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Instance of IApplicationBuilder</param>
        /// <param name="env">Instance of IWebHostEnvironment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();     

            app.UseHttpsRedirection();

            app.UseRouting();
             
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
