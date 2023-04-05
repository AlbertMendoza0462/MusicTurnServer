using Microsoft.EntityFrameworkCore;
using MusicTurn.DAL;
using MusicTurn.BLL;
using MusicTurn.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Context>(conn =>
        conn.UseSqlite(ConStr)
    );

builder.Services.AddScoped<CancionesBLL>();
builder.Services.AddScoped<ColaCancionesBLL>();


var _policyName = "GeeksPolicy";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: _policyName,
    policy =>
    {
        policy.WithOrigins
            ("http://localhost:5048", "http://localhost:3000", "http://albert0462.somee.com")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_policyName);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
