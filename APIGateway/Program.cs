using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("ocelot.json");
        });

        var authenticationProviderKey = "IdentityApiKey";

        builder.Services.AddAuthentication()
         .AddJwtBearer(authenticationProviderKey, x =>
         {
             x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
                                                     //x.RequireHttpsMetadata = false;
             x.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateAudience = false
             };
         });

        builder.Services.AddOcelot();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseOcelot();

        app.Run();
    }
}