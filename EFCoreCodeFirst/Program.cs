using AutoMapper;
using CRUDUsingEFCoreCodeFirst.Models;
using EFCoreCodeFirst.customFilters;
using EFCoreCodeFirst.Profiles;
using EFCoreCodeFirst.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new MyResourceFilter()); // Applied Resource filter globally
});

builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreCodeFirstDB"));

    //options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreCodeFirstDB"), 

    //    sqlOptions =>
    //    {
    //        sqlOptions.CommandTimeout(120); // 120 seconds command TimeOut
    //    });
});

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddSingleton<IMyService, MyService>();

builder.Services.AddScoped<IMyService, MyService>();

//builder.Services.AddTransient<IMyService, MyService>();

//builder.Services.AddScoped<MyResourceFilter>();
builder.Services.AddScoped<MyAuthorizationFilter>();
builder.Services.AddScoped<MyActionFilter>();
builder.Services.AddScoped<MyResultFilter>();
builder.Services.AddScoped<MyExceptionFilter>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
