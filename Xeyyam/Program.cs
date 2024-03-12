using Microsoft.EntityFrameworkCore;
using Xeyyam.DAL;
using Xeyyam.Repositories.Abstract;
using Xeyyam.Repositories.Concrete;
using Xeyyam.Services.Abstract;
using Xeyyam.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();    
builder.Services.AddScoped<ICategoryService,CategoryService>();    



var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
