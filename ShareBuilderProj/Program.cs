using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ShareBuilderProj.Data;
using ShareBuilderProj.Services;

var builder = WebApplication.CreateBuilder(args);
var connectingString = builder.Configuration.GetConnectionString("Default")??
    throw new NullReferenceException("No connection string in config!");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<StationDbContext>((DbContextOptionsBuilder options) =>
options.UseSqlServer(connectingString));
builder.Services.AddTransient<StationService>();
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

app.Run();

