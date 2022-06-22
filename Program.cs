using Microsoft.EntityFrameworkCore;
using XotaApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddDbContext<XotaContext>(opt => opt.UseInMemoryDatabase("XotaList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
