using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repository;


namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            //services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderDb")));
            //services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("c")));
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
