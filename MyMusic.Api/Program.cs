
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Repositories;
using MyMusic.Core.Services;
using MyMusic.Data.Data;
using MyMusic.Data.Repositories;
using MyMusic.Services;

namespace MyMusic.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers().AddJsonOptions(x =>
                   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
                   
        // builder.Services.AddControllers();


        var connectString = builder.Configuration.GetConnectionString("MyStrConnect");

        // builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
        // builder.Services.AddTransient<IMusicRepository, MusicRepository>();
        // addscoped



        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<IArtistService, ArtistService>();
        builder.Services.AddTransient<IMusicService, MusicService>();



        var app = builder.Build();



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
