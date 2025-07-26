using Microsoft.EntityFrameworkCore;
using GetQuestions.Services;
using GetQuestions.Models;
using GetQuestions.Data;
var builder = WebApplication.CreateBuilder(args);

// Datenbank-Verbindung einrichten
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<GetQuestionServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger

    app.UseSwagger();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


// app.UseHttpsRedirection(); // optional deaktivieren

app.UseAuthorization();

app.MapControllers();

app.Run();
