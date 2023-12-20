using StudentmManagement.Data;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;
using StudentmManagement.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IStudentManagementService), typeof(StudentManagementService));
//builder.Services.AddScoped<IStudentManagementService, StudentManagementService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
