using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete;
using Repositories.Context;
using Services.Abstract;
using Services.Concrete;
using Services.MappingProfiles;


var builder = WebApplication.CreateBuilder(args);

// CORS ayarlarý
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

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


builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
