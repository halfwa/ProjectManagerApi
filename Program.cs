using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi;
using ProjectManagerApi.Data;
using ProjectManagerApi.Data.Repositories.Implementations;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Extensions;
using ProjectManagerApi.Models.Employees;
using ProjectManagerApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>()
    .AddUnitOfWork()
        .AddCustomRepository<Project, ProjectsRepository>()
        .AddCustomRepository<Service, ServicesRepository>()
        .AddCustomRepository<Employee, EmployeesRepository>()
        .AddCustomRepository<Position, PositionsRepository>();

builder.Services.AddControllers();
builder.Services.AddScoped<IEmailRequest, EmailRequestService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

PrepDb.PrepPopulation(app);

app.Run();

