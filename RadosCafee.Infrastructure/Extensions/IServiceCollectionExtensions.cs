
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RadosCafee.Application.Interfaces.Repositories;
using RadosCafee.Domain.Common;
using RadosCafee.Domain.Common.Interfaces;
using RadosCafee.Infrastructure.Services;

namespace RadosCafee.Infrastructure.Extensions
{
    public static  class IServiceCollectionExtensions
    {
        public static void AddInfraStructureLayer (this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
