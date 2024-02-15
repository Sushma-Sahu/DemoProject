using DemoProject.Data;
using DemoProject.DataRepository;
using DemoProject.Interface;
using Microsoft.EntityFrameworkCore;
using DemoProject.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DemoDBContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnectionString")));
//Create  for db contect class so that object create only one time 
builder.Services.AddTransient<IDbEmployee, DbEmployeeRepo>();
//builder.Services.AddScoped<IEmployeesController, EmployeesController>();
//builder.Services.AddScoped<IDbEmployee, DbEmployeeRepo>();

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
