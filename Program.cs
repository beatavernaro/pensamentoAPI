using Microsoft.EntityFrameworkCore;
using pensamentoAPI.Data;
using pensamentoAPI.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PensamentoApiContext")
?? throw new InvalidOperationException("Connection String não encontrada")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

//You have to add services.AddCors() in ConfigureServices(IServiceCollection services)

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EndpointConfig.AddEndpoint(app);

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowCredentials()
            );
app.Run();
