using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotTemplate.OcelotApiGateway.OcelotAggregators;

var builder = WebApplication.CreateBuilder(args);
var environmentEnvironmentName = builder.Environment.EnvironmentName;
//Check existence of development ocelot file
if (File.Exists($"ocelot.{environmentEnvironmentName}.json"))
    builder.Configuration.AddJsonFile($"ocelot{environmentEnvironmentName}.json", false, true);

//Add Ocelot Configuration to app
builder.Configuration.AddJsonFile($"ocelot.json", false, true);


if (File.Exists("appsettings.json"))
    builder.Configuration.AddJsonFile($"appsettings.json", false, true);


builder.Services.AddOcelot(builder.Configuration)
    .AddSingletonDefinedAggregator<JoinProductWithProductCategoriesAggregator>();



var app = builder.Build();

//Use the ocelot middleware that handle the incoming request
app.UseOcelot()
    .Wait();


app.UseHttpsRedirection();
app.UseHttpLogging();


app.Run();
