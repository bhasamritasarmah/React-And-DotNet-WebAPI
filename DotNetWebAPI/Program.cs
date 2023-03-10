using Microsoft.Extensions.Options;
using MongoDB.Driver;
using React_and_WebAPI.Models;
using React_and_WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<PeopleDatabaseSettings>(
    builder.Configuration.GetSection(nameof(PeopleDatabaseSettings)));

builder.Services.AddSingleton<IPeopleDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PeopleDatabaseSettings>>().Value );

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetValue<string>("PeopleDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IPeopleService, PeopleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontEndURL = configuration.GetValue<string>("FrontEndURL");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontEndURL).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
