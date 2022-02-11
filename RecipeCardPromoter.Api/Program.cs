using RecipeCardPromoter.Api.Models;
using RecipeCardPromoter.Api.Services;
using RecipeCardPromoter.Api.Contracts;


var builder = WebApplication.CreateBuilder(args);
const string swaggerEndpoint = "/swagger/v1/swagger.json";

// Add services to the container.
builder.Services.AddSingleton<IRecipeSearchService, RecipeSearchService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
   c.SwaggerDoc("v1", new() { Title = "RecipeCardService", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerEndpoint, "recipecardservice.api v1"));
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();