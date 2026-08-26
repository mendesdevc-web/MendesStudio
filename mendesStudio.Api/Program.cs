using Studio.Date;
using Studio.Service.Interface;
using Studio.Service.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StudioAtendimentoContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StudioAtendimento")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();

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