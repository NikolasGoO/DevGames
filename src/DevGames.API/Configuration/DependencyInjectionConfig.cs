using DevGames.Application.Interfaces;
using DevGames.Application.Services;
using DevGames.Domain.Interfaces;
using DevGames.Domain.Shared.Transaction;
using DevGames.Infra.Data.Context;
using DevGames.Infra.Data.Repositories;
using DevGames.Infra.Data.Uow;
using MediatR;

namespace DevGames.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatr();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("DevGames.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DevGamesDbContext>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IVoucherAppService, VoucherAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IOrderItemAppService, OrderItemAppService>();
        }
    }
}
