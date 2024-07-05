using aspLearning.Context;
using aspLearning.Interfaces;
using aspLearning.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//TODO
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

//connection to DB
builder.Services.AddDbContext<MyContext>(options =>
{
    //global
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    //
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies(false);
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();