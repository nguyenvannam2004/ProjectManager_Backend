using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interface;
using MyApp.Application.Service;
using MyApp.Infracstructure.Repository;
using Microsoft.EntityFrameworkCore;
using MyApp.Infracstructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Thêm UseCors trước UseHttpsRedirection
app.UseCors("AllowAll");  // <<< Thêm dòng này

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();