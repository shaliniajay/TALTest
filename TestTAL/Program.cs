using Microsoft.EntityFrameworkCore;
using TestTAL.Api.BL;
using TestTAL.Api.DA;
using TestTAL.Api.FIlters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TALContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TALShaliniDatabase")));
builder.Services.AddScoped<IPremiumService, PremiumService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<UnhandledExceptionFilterAttribute>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
