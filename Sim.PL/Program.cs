using Microsoft.EntityFrameworkCore;
using Sim.BL.Profiles;
using Sim.BL.Services.Abstractions;
using Sim.BL.Services.Implementations;
using Sim.DAL.Contexts;
using Sim.DAL.Repositories.Abstractions;
using Sim.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IDepartmentService,DepartmentService>();
builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddAutoMapper(typeof(DoctorProfile));
builder.Services.AddAutoMapper(typeof(DepartmentProfile));

var app = builder.Build();
app.UseStaticFiles();





app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
