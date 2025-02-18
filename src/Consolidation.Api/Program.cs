using Consolidation.Application.Interfaces;
using Consolidation.Application.Services;
using Consolidation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Consolidation.Infrastructure.Database;
using Consolidation.Api.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionString"];
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de injeção de dependência
builder.Services.AddScoped<IConsolidationService, ConsolidationService>();
builder.Services.AddScoped<ConsolidationRepository>();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
