using System.Reflection;
using api.DTO;
using api.Reflection;
using data;
using data.Repository;
using Entity1;
using Microsoft.EntityFrameworkCore;
using model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(oBuilder =>
    oBuilder.UseSqlServer("Server=localhost;Database=Company_attendance;User Id=tnt;Password=1;encrypt=false;"));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
builder.Services.AddScoped<IBaseRepository<Attendance>, BaseRepository<Attendance>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
var className = "Attendance";
var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
var type = Type.GetType($"{assemblyName}.Models.{className}");
var obj = Activator.CreateInstance(type);
ReflectionHelper.SetPropertyValue(obj, "EmployeeId", 1);