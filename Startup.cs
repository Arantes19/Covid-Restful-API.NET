using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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
