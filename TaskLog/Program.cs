using Microsoft.EntityFrameworkCore;
using TaskLog.Database.Context;
using TaskLog.Repositories;
using TaskLog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SqLiteDbContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICustomTaskRepository, CustomTaskRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ITaskTimeSlipRepository, TaskTimeSlipRepository>();
builder.Services.AddScoped<ICustomTaskService, CustomTaskService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ITaskTimeSlipService, TaskTimeSlipService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: "AllowAll",
		configurePolicy =>
		{
			configurePolicy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
		});
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
