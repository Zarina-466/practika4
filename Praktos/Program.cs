using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestApiDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbString")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();
builder.Services.AddScoped<IGenresService, GenresService>();
builder.Services.AddScoped<IReadersService, ReadersService>();
builder.Services.AddScoped<IRentalService, RentalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
