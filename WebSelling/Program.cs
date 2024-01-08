using Microsoft.EntityFrameworkCore;
using System;
using WebSelling.Category;
using WebSelling.Models;

var builder = WebApplication.CreateBuilder(args);
String connectionString = "Data Source=LAPTOP-17SOHDC3\\MSSQLSERVER01;Initial Catalog=W-Device;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Configuration.GetConnectionString("WDeviceContext");
builder.Services.AddDbContext<WDeviceContext>(x=> x.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategory,RCategory>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
