using aspLearning.Context;
using aspLearning.Interfaces;
using aspLearning.Middleware;
using aspLearning.Services;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NuGet.Packaging.Signing;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "NewFolder"
});

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

//request1 => |routing| => endpoint1
//request2 => |routing| => endpoint2
//index
//shops
//orders
app.UseStaticFiles(); //access to NewFolder
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "MyWebRoot"))
}); //access to MyWebRoot
// app.Use(async (context, func) =>
// {
//     var endPoint = context.GetEndpoint();
//     await context.Response.WriteAsync($"before :{endPoint}");
//     await func();
// });
app.UseRouting(); //1
// app.Use(async (context, func) =>
// {
//     var endPoint = context.GetEndpoint();
//     await context.Response.WriteAsync($"after :{endPoint}");
//     await func();
// });
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthorization();

#region CustomMiddleware

app.UseElmah();
app.Use(async (context, @delegate) =>
{
    //await context.Response.WriteAsync("Middleware-1 ");
    await @delegate(context);
    //await context.Response.WriteAsync("after-Middleware-1 ");
    //after logic
});
app.UseWhen(context => context.Request.Query.ContainsKey("username"), applicationBuilder =>
{
    applicationBuilder.Use(async (context, @delegate) =>
    {
        //middleware
        //await context.Response.WriteAsync("called useWhen");
        await @delegate();
    });
});
//custom middleware
//app.UseMiddleware<CustomMiddleware>();
//app.UseMyCustomMiddleware();
//app.UseMiddleware<ConventionalMiddleware>(); //TODO : convert to extension

#endregion

//endpoints
//2

//URL(name , filename) => get => route parameter
//files/new.txt => files/{filename}.{extension}
//employee/profile/Ali => employee/profile/{name}
app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        var fileName = context.Request.RouteValues["filename"];
        var extension = context.Request.RouteValues["extension"];
        await context.Response.WriteAsync($"file : {fileName}.{extension}");
    });
    endpoints.Map("employee/profile/{title=AliChavoshi}", async context =>
    {
        var title = context.Request.RouteValues["title"];
        await context.Response.WriteAsync($"title of employee : {title}");
    });
    //ture
    //guid : 059D6025-996A-4276-9E96-AC0094B6B3C6
    //ALi
    //10 12 13 10000
    //1 2 -1 100
    //a-1 A-Z
    endpoints.Map("products/details/{year:int:min(1900):max(2030)}", async context =>
    {
        var id = context.Request.RouteValues["id"] ?? 5;
        await context.Response.WriteAsync($"id : {id}");
    });
    //map == post , put , get
    endpoints.MapGet("map1", async (context) => { await context.Response.WriteAsync("In Map-1"); });
    endpoints.MapPost("map2", async (context) => { await context.Response.WriteAsync("In Map-2"); });
});
app.Run(async context => { await context.Response.WriteAsync("Middleware-3 "); }); //end middleware
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();