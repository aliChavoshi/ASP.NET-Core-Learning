using aspLearning.Context;
using aspLearning.Interfaces;
using aspLearning.Middleware;
using aspLearning.Services;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//uwo
//generic
//
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// builder.Services.AddTransient<ITeaService,TeaService>();
// builder.Services.AddTransient<IRestaurantService, RestaurantService>();

//connection to DB
builder.Services.AddDbContextPool<MyContext>(options =>
{
    //global
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies(false);
});
//Elmah Log
builder.Services.AddElmah<SqlErrorLog>(opt =>
{
    opt.Path = "elmah";
    opt.ConnectionString = "Server=.;Database=Log_DB;User ID=sa;Password=@dminiskr@;MultipleActiveResultSets=true;";
});

builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();
builder.Services.AddTransient<CustomMiddleware>(); //present
//Redis Configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
    {
        AbortOnConnectFail = true,
        EndPoints = { options.Configuration }
    };
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//add custom middlewares
app.UseElmah();
         
app.Use(async (context, @delegate) =>
{
    await context.Response.WriteAsync("Middleware-1 ");
    await @delegate(context);
    await context.Response.WriteAsync("after-Middleware-1 ");
    //after logic
});
app.UseWhen(context => context.Request.Query.ContainsKey("username"), applicationBuilder =>
{
    applicationBuilder.Use(async (context, @delegate) =>
    {
        //middleware
        await context.Response.WriteAsync("called useWhen");
        await @delegate();
    });
});
//custom middleware
//app.UseMiddleware<CustomMiddleware>();
app.UseMyCustomMiddleware();
app.UseMiddleware<ConventionalMiddleware>(); //TODO : convert to extension

app.Run(async context =>
{
    await context.Response.WriteAsync("Middleware-3 ");
    //end of the middlewares 
});

app.Run();