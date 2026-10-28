using MeuCaixa.Cadastro.DataBase;
using MeuCaixa.Cadastro.Repositories.SqlServer;
using MeuCaixa.Cadastro.Repositories.SqlServer.Interfaces;
using MeuCaixa.Cadastro.Service;
using MeuCaixa.Cadastro.Service.Interface;
using MeuCaixa.Cadastro.Service.Validator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CadastroDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MeuCaixa")));

builder.Services.AddScoped<
    IDespesaSqlServerRepository,
    DespesaSqlServerRepository>();

builder.Services.AddScoped<DespesaValidator>();

builder.Services.AddScoped<IDespesaService, DespesaService>();

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
