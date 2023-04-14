namespace WebAPI
{
    using FluentValidation;

    using WebAPI.Extensions;
    using WebAPI.Interfaces;
    using WebAPI.Models;
    using WebAPI.Services;
    using WebAPI.Validators;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<ICacheService, CacheService>();
            builder.Services.AddWeatherService(builder.Configuration);
            builder.Services.AddScoped<IValidator<Input>, WeatherValidator>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(_ =>
            {
                _.AllowAnyHeader();
                _.AllowAnyMethod();
                _.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
