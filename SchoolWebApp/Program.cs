using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models.Entities;
using SchoolWebApp.Utility;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SchoolWebAppDB");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IGenericRepository<Student>), typeof(GenericRepository<Student>));
builder.Services.AddScoped(typeof(IGenericRepository<Course>), typeof(GenericRepository<Course>));
builder.Services.AddScoped(typeof(IGenericRepository<Instructor>), typeof(GenericRepository<Instructor>));
//builder.Services.AddScoped(typeof(IGenericRepository<Admin>), typeof(GenericRepository<Admin>));
builder.Services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = true;
                }).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();




builder.Services.AddScoped<IDBSeeding, DBSeeding>();

var app = builder.Build();



//This will make sure the application will create a default Admin login
//and also create other roles which can be used later on
using (var scope = app.Services.CreateScope())
{
    var dbSeeding = scope.ServiceProvider.GetRequiredService<IDBSeeding>();
    dbSeeding.Initialize();
}

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
