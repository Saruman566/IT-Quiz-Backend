using Microsoft.EntityFrameworkCore;
using GetQuestions.Services;
using GetQuestions.Models;
using GetQuestions.Data;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseMySQL(connectionString));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3002", "http://localhost:5073")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddScoped<GetQuestionServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "IT-Quiz-Backend",
        Version = "v1",
        Description = "Backend of the IT-Quiz",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Saruman566",
            Email = "email@example.com"
        }
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IT-Quiz-Backend V1");
});

app.UseRouting();

app.UseCors("AllowFrontend");


app.UseAuthorization();

app.MapControllers();

app.Run();
