using Microsoft.EntityFrameworkCore;
using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Data.Repositories;
using SassoInmobiliariaAPI.Data.Services;
using SassoInmobiliariaAPI.Services;
using SassoInmobiliariaAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repositories
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IDevelopmentPropRepository, DevelopmentPropRepository>();
#endregion

#region Services
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IDevelopPropService, DevelopPropService>();
#endregion

#region Database  
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 2))));
#endregion

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
