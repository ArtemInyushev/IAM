using IAM.ClientApi.Mapping;
using IAM.ClientApi.Middlewares;
using IAM.Core.Interfaces;
using IAM.Infrastructure.Data;
using IAM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

builder.Services.AddDbContext<IamDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IAMConnectionString"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(IamRepository<>));
builder.Services.AddScoped<IDataSeeder, DataSeeder>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors();

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

// Fill database with test data
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    await dataSeeder.SeedData();
}

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
