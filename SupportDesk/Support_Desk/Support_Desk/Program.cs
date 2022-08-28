using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Support_Desk.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Password.RequireLowercase = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    opt.Lockout.MaxFailedAccessAttempts = 1;

});
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
    pattern: "{controller=Authentication}/{action=Login}/{id?}");

app.Run();
