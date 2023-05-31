using FitnessApp.Core.Application.Configuration;
using FitnessApp.Web.Api.Configuration.Swagger;
using FitnessApp.IoC.Web.Api;
using System.Text.Json.Serialization;
using FitnessApp.Web.Api.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddWebApiDependencies(builder.Configuration);
builder.Services.AddMediatorServices().AddValidators();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});
builder.Services.AddVersionedApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddConfiguredSwagger();
builder.Services.AddHealthCheck(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseConfiguredSwagger();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthCheck(builder.Configuration);

app.Run();

// Used for integration tests
public partial class Program { }