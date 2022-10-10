using System.Reflection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LabSysCloud.Application.Models.Mappings;
using LabSysCloud.CrossCuting.Middleware;
using LabSysCloud.Data.Context;
using LabSysCloud.Data.Repositories;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Domain.Services;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Fluent-Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationClientsideAdapters();

//Injeção de Repositórios e Serviços
builder.Services.AddScoped<IRepositorioBase<Paciente>, RepositorioBase<Paciente>>();
builder.Services.AddScoped<IServicoBase<Paciente>, ServicoBase<Paciente>>();

builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LabSysCloud API",
        Version = "v1",
        Description = "API do sistema LabSysCloud, desenvolvido na disciplina de C#",
        Contact = new OpenApiContact() { Name = "ELFUTEC", Email = "coordenacao.elfutec@gmail.com", Url = new Uri("http://www.elfutec.com")}
    });
});

var connectionString = builder.Configuration.GetConnectionString("LabSysCloudConn");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("LabSysCloud.Data")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "LabSysCloud");
        options.RoutePrefix = string.Empty;        
    });    
}

//Configure Auto-Mapper
builder.Services.AddAutoMapper(
    typeof(PacienteProfile)
);

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");

app.UseRewriter(option);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapControllers();

UpdateDatabase(app);

app.Run();

void UpdateDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
        {
            context.Database.Migrate();            
        }
    }
}
