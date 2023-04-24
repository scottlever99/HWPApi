using HWPApi.Data;
using HWPApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conString = builder.Configuration.GetConnectionString("Default") ?? "";
builder.Services.AddDbContext<HWPDatabase>(options => options.UseMySQL(conString));

builder.Services.AddScoped<TemplateService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<HistoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
