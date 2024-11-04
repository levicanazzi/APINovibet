using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Novibet.API.HostedServices.IPAddresses;
using Novibet.Application.Countries.CommandSide.Commands.Find;
using Novibet.Application.Countries.CommandSide.Repositories;
using Novibet.Application.Countries.CommandSide.Services;
using Novibet.Application.IPAdresses.CommandSide.Repositories;
using Novibet.Domain.Notifications;
using Novibet.Infrastructure.Core.HostedServices;
using Novibet.Infrastructure.Core.Mediatr;
using Novibet.Infrastructure.Core.Repositories;
using Novibet.Infrastructure.Core.Web.API.Validators;
using Novibet.Repository.Context;
using Novibet.Repository.Countries;
using Novibet.Repository.Countries.Services;
using Novibet.Repository.IPAddresses;
using Novibet.Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NovibetDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<HostedServiceSettings>(builder.Configuration.GetSection("HostedServiceSettings"));


builder.Services
    .AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblyContaining<FindCountryCommandValidator>());

builder.Services
    .AddMemoryCache()
    .AddMediatR(typeof(FindCountryCommand).Assembly)
    .AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<ICountryRepository, CountryRepository>()
    .AddTransient<IIPAddressRepository, IPAddressRepository>()
    .AddTransient<ICountryService, CountryService>()
    .AddHostedService<UpdateIPAddressHostedService>()
    .AddTransient<RequestStateValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Novibet.API", Version = "v1" });
});

var app = builder.Build();

// This part is to run migrations on build Project
//using (var serviceScope = app.Services.CreateScope())
//{
//    var dbContext = serviceScope.ServiceProvider.GetRequiredService<NovibetDbContext>();
//    dbContext.Database.Migrate();
//} 

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
