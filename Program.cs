using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using Microsoft.EntityFrameworkCore;
using QuestionnaireApp2.Repositories;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException("Connection string 'DbConnection' not found.");

builder.Services.AddDbContext<QuestionnaireAppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<ICosmosDbService>(sp => new CosmosDbService(builder.Configuration));

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod().AllowAnyOrigin();
        });
});

builder.Services.AddTransient<ICustomQuestionRepository, CustomQuestionRepository>();
builder.Services.AddTransient<IPersonalInformationRepository, PersonalInformationRepository>();
builder.Services.AddTransient<IProgramRepository, ProgramRepository>();
builder.Services.AddTransient<IQuestionValueRepository, QuestionValueRepository>();
builder.Services.AddTransient<IQuestionTypeRepository, QuestionTypeRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("_myAllowSpecificOrigins");

var scope = app.Services.CreateScope();
var cosmosDbService = scope.ServiceProvider.GetRequiredService<ICosmosDbService>();
await cosmosDbService.SeedDataAsync();

app.Run();


