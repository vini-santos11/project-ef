using Application.Configurations;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", ".env");
DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { envFilePath }));

// Add services to the container.
builder.Services.AddDatabaseSetup();
builder.Services.AddDependencyInjection();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
