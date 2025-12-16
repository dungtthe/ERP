using ERP.Application.Abstractions.Authentication;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Abstractions.Services;
using ERP.Domain.Repositories;
using ERP.Infrastructure.Authentication;
using ERP.Infrastructure.Persistence;
using ERP.Infrastructure.Persistence.Repositories;
using ERP.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));
            });
            services.AddScoped<IReadAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCatergoryRepository, ProductCatergoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<IAttributeValueRepository, AttributeValueRepository>();
            services.AddScoped<IProductVariantAttributeValue, ProductVariantAttributeValue>();
            services.AddScoped<IBillOfMaterialRepository, BillOfMaterialRepository>();
            services.AddScoped<IBillOfMaterialItemRepository, BillOfMaterialItemRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}
