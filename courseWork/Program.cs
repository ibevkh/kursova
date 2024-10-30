using courseWork.Entity;
using courseWork.Services;
using courseWork.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()    // ��������� ������ � ����-����� ������ (�����)
            .AllowAnyMethod()    // ��������� ����-���� HTTP ����� (GET, POST, PUT ����)
            .AllowAnyHeader();   // ��������� ����-�� HTTP ���������
        });
});

builder.Services.AddScoped<IJewelleryService, JewelleryService>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddDbContext<JewelleryContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
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

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
