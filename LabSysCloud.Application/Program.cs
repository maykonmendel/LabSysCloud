using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LabSysCloud.Application.Models.Mappings;
using LabSysCloud.CrossCuting.Middleware;
using LabSysCloud.Data.Context;
using LabSysCloud.Data.Repositories;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReflectionIT.Mvc.Paging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure Auto-Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddPaging(options =>
{
    options.PageParameterName = "pageIndex";
});

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();

//Fluent-Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationClientsideAdapters();

//Autenticação
var key = Encoding.ASCII.GetBytes(builder.Configuration["LabSysCloud:ServiceApiKey"]);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//Injeção de Repositórios e Serviços
builder.Services.AddScoped<IRepositorioBase<Paciente>, RepositorioBase<Paciente>>();
builder.Services.AddScoped<IServicoBase<Paciente>, ServicoBase<Paciente>>();
builder.Services.AddScoped<IRepositorioBase<Usuario>, RepositorioBase<Usuario>>();
builder.Services.AddScoped<IServicoBase<Usuario>, ServicoBase<Usuario>>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LabSysCloud API",
        Version = "v1",
        Description = "API do sistema LabSysCloud, desenvolvido na disciplina de C#",
        Contact = new OpenApiContact() { Name = "ELFUTEC", Email = "coordenacao.elfutec@gmail.com", Url = new Uri("http://www.elfutec.com") }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new String[]{}
        }
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

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");

app.UseRewriter(option);

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
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
