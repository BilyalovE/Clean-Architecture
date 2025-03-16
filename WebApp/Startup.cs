using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application;
using Application.Order.Commands.CreateOrder;
using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.WebApp;
using Infrastructure.Interfaces.Email;
using Infrastructure.Implementation.DataAccess;
using Infrastructure.Implementation.Email;
using DomainServices.Interfaces;
using DomainServices.Implementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.ApplicationServices.Interfaces;
using UseCases.ApplicationServices.Implementation;


namespace WebApp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Domain
        services.AddScoped<IOrderDomainService, OrderDomainService>();
        
        // Infrastructure
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddDbContext<IDbContext, AppDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        
        // Mobile.UseCases
        services.AddMediatR(typeof(CreateOrderCommand));
        services.AddScoped<ISecurityService, SecurityService>();
        
        
        // Framework
        services.AddControllers();
        services.AddAutoMapper(typeof(MapperProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}