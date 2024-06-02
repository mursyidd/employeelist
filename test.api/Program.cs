using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDb>(opt => opt.UseInMemoryDatabase("EmployeeList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee API",
        Description = "API for managing a list of employee and their details.",
    });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<EmployeeDb>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("/employeelist", async (EmployeeDb db) =>
   await db.Employee.ToListAsync())
   .WithTags("Get all employee");

app.MapGet("/employeelist/{id}", async (int id, EmployeeDb db) =>
    await db.Employee.FindAsync(id)
        is Employee employee
            ? Results.Ok(employee)
            : Results.NotFound())
    .WithTags("Get employee by Id");

app.MapPost("/employeelist", async (Employee employee, EmployeeDb db) =>
{
    db.Employee.Add(employee);
    await db.SaveChangesAsync();

    return Results.Created($"/employeelist/{employee.Id}", employee);
})
    .WithTags("Add employee to list");

app.MapPut("/employeelist/{id}", async (int id, Employee inputEmployee, EmployeeDb db) =>
{
    var employee = await db.Employee.FindAsync(id);

    if (employee is null) return Results.NotFound();

    employee.username = inputEmployee.username;
    employee.mail = inputEmployee.mail;
    employee.phone_no = inputEmployee.phone_no;
    employee.skill_set = inputEmployee.skill_set;
    employee.hobby = inputEmployee.hobby;


    await db.SaveChangesAsync();

    return Results.NoContent();
})
    .WithTags("Update employee by Id");

app.MapDelete("/employeelist/{id}", async (int id, EmployeeDb db) =>
{
    if (await db.Employee.FindAsync(id) is Employee employee)
    {
        db.Employee.Remove(employee);
        await db.SaveChangesAsync();
        return Results.Ok(employee);
    }

    return Results.NotFound();
})
    .WithTags("Delete employee by Id");


app.UseSwagger();
app.UseSwaggerUI();


app.Run();