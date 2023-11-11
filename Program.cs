using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TORO.Authentication;
using TORO.Data;
using TORO.Data.Context;
using TORO.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
#region Configuracion de la base de datos SQLite
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
#endregion
#region Servicios
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IAnimalServices,AnimalServices>();
builder.Services.AddScoped<IRazaServices,RazaServices>();
builder.Services.AddScoped<ILostAnimalServices,LostAnimalServices>();
builder.Services.AddScoped<IGastoServices,GastoServices>();
builder.Services.AddScoped<IFacturaServices,FacturaServices>();
#endregion
#region Authentication
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddScoped<IUserAccountService,UserAccountService>();
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

using (var serviceScope =  app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider
        .GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
