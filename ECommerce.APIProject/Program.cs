using ECommerce.APIProject.Config;
using ECommerce.InfaStructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

//DI
builder.Services.AddDbContext<WebSiteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB1"));
});

builder.Services.AddAccountScopes();
builder.Services.AddCategoriesScopes();
builder.Services.AddProductsScopes();

builder.Services.ConfigAuth(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.ConfigSwagger();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo v1"));
}
app.UseStaticFiles();
app.UseCors("MyPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
