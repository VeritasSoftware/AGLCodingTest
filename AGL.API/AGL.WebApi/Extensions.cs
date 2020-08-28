using AGL.Application;
using AGL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGL.WebApi
{
    public static class Extensions
    {
        public static void AddPetStore(this IServiceCollection services, IConfiguration configuration)
        {
            //Get AGL section from AppSettings
            var aglSection = configuration.GetSection("AGL").Get<AGLSettings>();
            //Get API Url
            var apiUrl = aglSection.ApiUrl;

            //add dependency injection
            services.AddScoped<IPetsRepository, PetsRepository>(x => new PetsRepository { Url = apiUrl });
            services.AddScoped<IPetsManager, PetsManager>();
            services.AddSingleton<IMapperService, MapperService>();
        }
    }
}
