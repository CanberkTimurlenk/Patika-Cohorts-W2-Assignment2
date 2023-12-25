using ECommerceApi.Contexts;
using ECommerceApi.Extensions;
using ECommerceApi.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Add Session - for login requirement
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add Extension - For extension Requirement
builder.Services.AddServices();

builder.Services.AddLogging(builder => builder.AddConsole());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.AddExceptionHandlerMiddleware();
app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<EndpointLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
