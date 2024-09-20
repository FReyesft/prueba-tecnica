using Inmersys.Api.Data.Context;
using Inmersys.Bussines.Services;
using Inmersys.Core.Repositories;
using Inmersys.Core.Services;
using Inmersys.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmployeesService, EmployeesService>();
builder.Services.AddDbContext<InmersysDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("inmersys_db"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();