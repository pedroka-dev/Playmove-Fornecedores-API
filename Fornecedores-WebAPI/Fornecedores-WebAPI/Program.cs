using Fornecedores_Model.Features;
using Fornecedores_ORM;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FornecedorDBContext>();
builder.Services.AddScoped<BaseRepository<Forneceddor>>();
builder.Services.AddControllers();
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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FornecedorDBContext>();
    var pendingChanges = db.Database.GetPendingMigrations();
    if (pendingChanges.Any())
        db.Database.Migrate();
}

app.Run();
