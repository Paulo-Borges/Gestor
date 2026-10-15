using Gestor.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//CONECTANDO O SWAGGER ------------x-------------------1--------------
builder.Services.AddSwaggerGen();

//CONECTANDO O DEFAULTCONNECTION ------------x-------------------2--------------
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//CONECTANDO O CORS ------------x-------------------3--------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllAngular", Policy =>
    Policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //CONECTANDO O SWAGGER ------------x-------------------1--------------
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//CONECTANDO O CORS ------------x-------------------3--------------
app.UseCors("AllAngular");

app.MapControllers();

app.Run();
