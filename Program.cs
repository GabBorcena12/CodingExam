using Microsoft.EntityFrameworkCore;
using PizzaPlace.DBContext;
using System.Reflection;
using PizzaPlace.Repository;

#region Services
var builder = WebApplication.CreateBuilder(args);

// Configure Swagger to include XML comments only for controllers (HTTP endpoints)
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true); // Include only controller (HTTP endpoint) comments
});

// Register the ImportCsvData service
builder.Services.AddScoped<ImportCsvData>();
builder.Services.AddScoped<OrderDetailsRepository>();


// Register the DbContext with the dependency injection container
builder.Services.AddDbContext<PizzaPlaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaPlaceDb")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration
builder.Services.AddSwaggerGen();
#endregion Services

#region App

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion App
