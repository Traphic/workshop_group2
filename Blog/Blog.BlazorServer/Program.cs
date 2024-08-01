using Blazored.LocalStorage;
using Blog.BlazorServer.Components;
using Blog.BlazorServer.Clients.Interfaces;
using Blog.BlazorServer.States;
using Microsoft.AspNetCore.Components.Authorization;
using Blog.BlazorServer.Clients;
using Blog.BlazorServer.Clients.HttpHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddBlazorBootstrap();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

// Register services
builder.Services.AddScoped(typeof(IAuthClient), typeof(AuthClient));
builder.Services.AddScoped(typeof(IPostClient), typeof(PostClient));
builder.Services.AddScoped(typeof(ICategoryClient), typeof(CategoryClient));
builder.Services.AddScoped(typeof(ICommentClient), typeof(CommentClient));

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp =>
{
    var httpClientHandler = new HttpClientHandler();

    var authHeaderHandler = new AuthHeaderHandler(sp.GetRequiredService<ILocalStorageService>());

    authHeaderHandler!.InnerHandler = httpClientHandler;

    var httpClient = new HttpClient(authHeaderHandler)
    {
        BaseAddress = new Uri("https://localhost:51800")
    };

    return httpClient;
});

builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
