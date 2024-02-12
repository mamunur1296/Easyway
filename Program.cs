using Microsoft.EntityFrameworkCore;
using Easyway.Areas.Identity.Data;
using Easyway.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>();


var provaider = builder.Services.BuildServiceProvider();
var config = provaider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<ContactDBContext>(item => item.UseSqlServer(config.GetConnectionString("ApplicationDBContextConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(p => p.AddPolicy("CorsPolici", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("CorsPolici");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseWebSockets();
app.MapRazorPages();
app.Run();
