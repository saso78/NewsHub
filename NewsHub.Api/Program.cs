using NewsHub.Data.Context;
using Microsoft.EntityFrameworkCore;
using NewsHub.Data.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDbContext<NewsHubDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}