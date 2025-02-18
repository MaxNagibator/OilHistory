using OilHistory.Web.Business.BackgroundServices;
using OilHistory.Web.Components;
using OilHistory.Web.Extensions.EndpointExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition)); 
builder.Services.AddHostedService<BackgroundExecutorService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
} 
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(OilHistory.Client._Imports).Assembly);
app.UseEndpointDefinitions();
app.Run();
