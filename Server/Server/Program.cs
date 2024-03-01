
using Microsoft.EntityFrameworkCore;
using Server.Clients;
using Server.Data;
using Server.Optional;

var builder = WebApplication.CreateBuilder(args);

var connectionData = builder.Configuration.GetConnectionString("ConnectionData");
var connectionClients = builder.Configuration.GetConnectionString("ConnectionClients");
var connectionOptional = builder.Configuration.GetConnectionString("ConnectionOptional");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connectionData));
builder.Services.AddDbContext<ClientContext>(options =>
    options.UseNpgsql(connectionClients));
builder.Services.AddDbContext<OptionalContext>(options =>
    options.UseNpgsql(connectionOptional));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
