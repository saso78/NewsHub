using Microsoft.EntityFrameworkCore;
using NewsHub.Data.Context;
using NewsHub.Data.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()  // Allows requests from any origin
                       .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
                       .AllowAnyHeader(); // Allows any header
            });
        });
        // Add services to the container.
        builder.Services.AddDbContext<NewsHubDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseCors("AllowAllOrigins");
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}