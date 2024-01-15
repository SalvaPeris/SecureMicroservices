using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Net.Http.Headers;
using Movies.Client.ApiServices;
using Movies.Client.HttpHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieApiService, MovieApiService>();


// 1 create an HttpClient used for accessing the Movies.API
builder.Services.AddTransient<AuthenticationDelegatingHandler>();

builder.Services.AddHttpClient("MovieAPIClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
}).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

// 2 create an HttpClient used for accessing the IDP
builder.Services.AddHttpClient("IDPClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5005/");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddHttpContextAccessor();

//builder.Services.AddSingleton(new ClientCredentialsTokenRequest
//{
//    Address = "https://localhost:5005/connect/token",
//    ClientId = "movieClient",
//    ClientSecret = "secret",
//    Scope = "movieAPI"
//});

builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:5005";

                    options.ClientId = "movies_mvc_client";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code id_token";

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("movieAPI");

                    //options.Scope.Add("address");
                    //options.Scope.Add("email");
                    //options.Scope.Add("roles");

                    //options.ClaimActions.DeleteClaim("sid");
                    //options.ClaimActions.DeleteClaim("idp");
                    //options.ClaimActions.DeleteClaim("s_hash");
                    //options.ClaimActions.DeleteClaim("auth_time");
                    //options.ClaimActions.MapUniqueJsonKey("role", "role");



                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                });




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
