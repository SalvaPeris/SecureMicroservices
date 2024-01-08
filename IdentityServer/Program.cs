using IdentityServer;
using IdentityServer4.Test;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddTestUsers(Config.TestUsers)
                .AddDeveloperSigningCredential();

        var app = builder.Build();

        app.UseIdentityServer();

        app.Run();

    }
}