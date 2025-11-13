using Microsoft.EntityFrameworkCore;
using MyApp.Application.Profiles;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Context;
using MyApp.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Config EF core
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// config repositories
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Adicionando AutoMapper
builder.Services.AddAutoMapper(cfg =>
{

},
typeof(ProdutoProfile).Assembly);

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
