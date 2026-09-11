using Microsoft.EntityFrameworkCore;
using Studio.Date;
using Studio.Service.Interface;
using Studio.Service.Service;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<StudioAtendimentoContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StudioAtendimento")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPostoService, PostoService>();

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