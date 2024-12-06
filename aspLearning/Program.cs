using aspLearning.Binders;
using aspLearning.Context;
using aspLearning.Filters;
using aspLearning.Interfaces;
using aspLearning.Middleware;
using aspLearning.Services;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Add custom model binder
    options.ModelBinderProviders.Insert(0, new CourseBinderProvider());
    //options.Filters.Add<CourseIndexActionFilter>();
    //options.Filters.Add<HandleExceptionFilter>();
    options.Filters.Add<AddCustomHeaderFilter>();
    options.Filters.Add(new CourseIndexActionFilter("order", "global", 3));
});
builder.Services.AddHttpLogging(options =>
{
    options.RequestBodyLogLimit = 32;
    options.LoggingFields = HttpLoggingFields.All;
});
// Register scoped and transient services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
// Database context configuration
builder.Services.AddDbContextPool<MyContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
        .UseLazyLoadingProxies(false);
});

// Add middleware and caching services
builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();
builder.Services.AddTransient<CustomMiddleware>();
builder.Services.AddScoped<MyServiceFilter>();   //lifetime

var app = builder.Build();
app.UseHttpLogging();
// Configure the HTTP request pipeline
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    //app.UseDeveloperExceptionPage();
    app.UseExceptionHandlingMiddleware();
}


app.UseStaticFiles();
app.UseRouting();
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthorization();

// Configure endpoints
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();