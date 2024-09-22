using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Simulation.Data;
using Rent_A_Car_Simulation.Repositories;
using Rent_A_Car_Simulation.Repository_Interfaces;
using Rent_A_Car_Simulation.Service_Interfaces;
using Rent_A_Car_Simulation.Services;
using Rent_A_Car_Simulation.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentACarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarRepository, CarRepository>();
//  builder.Services.AddScoped<CarService>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IFuelRepository, FuelRepository>();
builder.Services.AddScoped<ITransmissionRepository, TransmissionRepository>();

// Register services for Dependency Injection
builder.Services.AddScoped<ICarService, CarService>(); 
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IFuelService, FuelService>();
builder.Services.AddScoped<ITransmissionService, TransmissionService>();


builder.Services.AddAutoMapper(typeof(Program));

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
