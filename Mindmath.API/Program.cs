using Mindmath.API.Extension;
using Mindmath.Application.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureCors();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.ConfigureRepositorymanager();
builder.Services.AddApplicationServices();
builder.Services.ConfigureIdentity();
builder.Services.AddAuthentication();
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.MapType<DateOnly>(() => new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string", Format = "date" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
