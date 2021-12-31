using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using MyBooksRecommendations.Api.GraphQL;
using MyBooksRecommendations.Application;
using MyBooksRecommendations.Application.Services.AutoMapper;
using MyBooksRecommendations.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddUseCases();

builder.Services.AddScoped<ISchema, BookScheme>(services => new BookScheme(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
}).AddSystemTextJson();

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapping());
}).CreateMapper());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseGraphQLAltair();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>();

app.Run();

public partial class Program { }
