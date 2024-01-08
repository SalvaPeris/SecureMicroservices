using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Movies.API.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MoviesContext>(options =>
                    options.UseInMemoryDatabase("Movies"));

        var app = builder.Build();

        SeedDatabase(app);

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

    private static void SeedDatabase(IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var moviesContext = services.GetRequiredService<MoviesContext>();
            MoviesContextSeed.SeedAsync(moviesContext);
        }
    }
}