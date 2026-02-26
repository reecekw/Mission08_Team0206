using Microsoft.EntityFrameworkCore;
using Mission08_Team0206.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services for controllers and views
builder.Services.AddControllersWithViews();

// Register the SQLite database context with the connection string from appsettings.json
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection")));

// Register the repository pattern: inject ITaskRepository as EFTaskRepository
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

// Configure error handling and HSTS for production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware pipeline configuration
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

// Set the default route pattern: Home/Index is the landing page
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
