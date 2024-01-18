using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolSystem.Persistence;
using SchoolSystem.Persistence.Context;
using School1system.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(Options =>
Options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnectionString")));
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) => 
{
    context.Request.Headers.Add("X-Core", "CoreRequest");
    await next.Invoke();
    var responseHeaders = context.Response.Headers;
    foreach (var header in responseHeaders)
    {
        Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
