using ECommerce.APIProject.Config;
using ECommerce.InfaStructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI

builder.Services.AddDbContext<WebSiteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB1"));
});

builder.Services.AddCategoriesScopes();
builder.Services.AddProductsScopes();

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
