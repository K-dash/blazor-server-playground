using blazor_playground.Components;
using blazor_playground.Data;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();

// DbContextの登録
builder.Services.AddDbContextFactory<PubsDbContext>(opt => {
    if (builder.Environment.IsDevelopment()) {
        opt = opt.EnableSensitiveDataLogging().EnableDetailedErrors();
    }
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        providerOptions => {
            providerOptions.EnableRetryOnFailure();
        }
    );
});

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


app.Run();
