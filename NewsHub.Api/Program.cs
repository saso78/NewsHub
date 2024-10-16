using Microsoft.EntityFrameworkCore;
using NewsHub.Data.Context;
using NewsHub.Data.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddDbContext<NewsHubDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();  // Enable Swagger middleware.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewsHub API v1");
            c.RoutePrefix = "swagger";  // Set Swagger UI to the root URL (optional).
        });
        app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}