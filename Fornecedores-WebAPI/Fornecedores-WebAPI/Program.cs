using Fornecedores_Model.Features;
using Fornecedores_ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FornecedorDBContext>();
builder.Services.AddScoped<BaseRepository<Forneceddor>>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Playmove Forncederoes WebAPI",
        Description = "Feita para o processo seletivo da Playmove ;)",
        Contact = new OpenApiContact
        {
            Name = "Pedro Henric Pinheiro Rosário",
            Url = new Uri("https://www.linkedin.com/in/pedro-henric-p-rosario/"),
            Email = "pedro.henric.rosario@gmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://github.com/pedroka-dev/Playmove-Fornecedores-WebAPI/blob/main/LICENSE")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FornecedoresWebAPI");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });

}

app.UseStaticFiles();
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
