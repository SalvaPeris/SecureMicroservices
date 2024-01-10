using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        builder.Services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:5005";
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
                    });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "movieClient", "movies_mvc_client"));
        });

        var app = builder.Build();

        SeedDatabase(app);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
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