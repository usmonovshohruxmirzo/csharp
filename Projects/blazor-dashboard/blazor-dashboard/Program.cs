using blazor_dashboard.Components;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Register Radzen ThemeService
builder.Services.AddScoped<ThemeService>();

// Add Razor Components + Server interactive mode
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
