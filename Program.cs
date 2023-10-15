using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TORO.Data;
using TORO.Data.Context;
using TORO.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
#region Configuracion de la base de datos SQLite
builder.Services.AddSqlite<MyDbContext>("Data Source=.//Data//Context//Toro.sqlite");
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
#endregion
#region Servicios
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IAnimalServices,AnimalServices>();
builder.Services.AddScoped<IGastoServices,GastoServices>();
builder.Services.AddScoped<IFacturaServices,FacturaServices>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
}

app.Run();
