using MyController.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllersWithViews(); //razor page => MVC

var app = builder.Build();
//controller => class => group actions => handling your request
//actions => endpoint => URL => endpoint => action => run => Response
//app.MapGet("/", () => "Hello World!");
app.MapControllers(); //used active routing Controller
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();