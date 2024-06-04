using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using test.web.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EmployeeModels") ?? "Data Source=EmployeeModels.db";
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddDbContext<EmployeeDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSqlite<EmployeeDb>(connectionString);

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "PizzaStore API",
//        Description = "Making the Pizzas you love",
//        Version = "v1"
//    });
//});

// Begin HTTP client code

// Add IHttpClientFactory to the container and set the name of the factory
// to "EmployeeAPI". The base address for API requests is also set.
builder.Services.AddHttpClient("EmployeeAPI", httpClient =>
{
    //httpClient.BaseAddress = new Uri("http://localhost:5050/employeelist/");
    httpClient.BaseAddress = new Uri("https://employeeapi-mursyid.azurewebsites.net/employeelist/");
});
// End of HTTP client code


// Add services to the container.
//builder.Services.AddDbContext<MyDbContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//        new MySqlServerVersion(new Version(8, 0, 21))));

//builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    //});
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
