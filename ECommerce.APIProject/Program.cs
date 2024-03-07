using ECommerce.APIProject.Config;
using ECommerce.Core.ConfigModels;
using ECommerce.InfaStructure.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//DI
builder.Services.AddDbContext<WebSiteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB1"));
});

builder.Services.Configure<JwtConfigModel>(builder.Configuration.GetSection("JWT"));

builder.Services.AddAccountScopes();
builder.Services.AddCategoriesScopes();
builder.Services.AddProductsScopes();
builder.Services.AddRedisServices(builder.Configuration);
builder.Services.AddDIForBasketServices();

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
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
