using aspLearning.Context;
using aspLearning.Interfaces;
using aspLearning.Services;
using ElmahCore.Mvc;
using ElmahCore.Sql;
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

app.UseElmah();
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();