using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Application;
using AGL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AGL.WebApi
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
            //Get AGL section from AppSettings
            var aglSection = this.Configuration.GetSection("AGL").Get<AGLSettings>();
            //Get API Url
            var apiUrl = aglSection.ApiUrl;

            //add dependency injection
            services.AddScoped<IPetsRepository, PetsRepository>(x => new PetsRepository { Url = apiUrl });
            services.AddScoped<IPetsManager, PetsManager>();

            //Add CORS support
            services.AddCors();

            services.AddControllers();
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

            //Add CORS support
            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}