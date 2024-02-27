using back_project.Data;
using back_project.Entities;
using back_project.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
builder.Services.AddDbContext<AppDbContext>( options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IRepositoryGeneric<Driver>, DriverRepository>();
builder.Services.AddTransient<IRepositoryGeneric<Vehicle>, VehicleRepository>();
builder.Services.AddTransient<IRepositoryGeneric<Journey>, RouteRepository>();
builder.Services.AddTransient<DriverService>();
builder.Services.AddTransient<RouterService>();
builder.Services.AddTransient<VehicleService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapIdentityApi<IdentityUser>(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("policy"); 

app.MapControllers();

app.Run();
