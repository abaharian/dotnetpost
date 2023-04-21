using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//read connection string from appsettings.json
using IHost host = Host.CreateDefaultBuilder(args).Build();
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
string? connectionString = config.GetValue<string>("connectionstring");
if(connectionString == null)
    throw new Exception("can not find connection string in appsettings.json");
dotnetpost.GlobalConfig.init(connectionString ?? "Default or throw");
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<dotnetpost.models.MyDbContext>(options =>
            options.UseNpgsql(connectionString));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
