using Microsoft.EntityFrameworkCore;
using webapi.DB_Service;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("FirstDbConnectionString");
// ��������� �������� Dbservice � �������� ������� � ����������
builder.Services.AddDbContext<DbService>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<DbService>();
// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder.WithOrigins("https://localhost:7151/")
//                .AllowAnyHeader()
//                .AllowAnyMethod(); //THIS LINE RIGHT HERE IS WHAT YOU NEED
//        });
//});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader()
                                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();