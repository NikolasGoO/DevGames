using Microsoft.OpenApi.Models;

namespace DevGames.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "DevGames API",
                    Description = "Essa API é feita para um projeto do curso de Programador de Sistemas do Senac",
                    Contact = new OpenApiContact()
                    {
                        Name = "Nikolas Gomes",
                        Email = "nikolasgomes925@gmail.com"
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });
        }
    }
}
