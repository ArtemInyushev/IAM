using IAM.ClientApi.Middlewares;
using IAM.Core.Interfaces;
using IAM.Infrastructure.Data;
using IAM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<IamDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IAMConnectionString"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(IamRepository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
