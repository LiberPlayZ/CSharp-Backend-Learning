using MongoDB.Driver;
using MyCSharpBackend.Config;
using MyCSharpBackend.Interfaces;
using MyCSharpBackend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDbConfig"));


builder.Services.AddSingleton<MongoDbService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
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
app.MapControllers(); // This enables your controllers



app.Run();

