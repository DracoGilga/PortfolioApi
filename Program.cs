using GithubFavoritesApi.GraphQL;
using GithubFavoritesApi.Services;
using GithubFavoritesApi.Services.Interfaces;
using GithubFavoritesApi.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueFrontend", policy =>
    {
        policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient<IGithubService, GithubService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<GithubQuery>()
    .AddMutationType<EmailMutation>();

var app = builder.Build();

app.UseCors("AllowVueFrontend");

app.MapGraphQL();

app.Run();
