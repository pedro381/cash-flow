using Transactions.Application.Interfaces;
using Transactions.Application.Services;
using Transactions.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Transactions.Infrastructure.Database;
using Transactions.Api.Mappings;

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
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<TransactionRepository>();

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
