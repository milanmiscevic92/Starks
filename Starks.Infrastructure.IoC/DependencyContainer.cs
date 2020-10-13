using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Starks.Application.Interfaces;
using Starks.Application.Services;
using Starks.Domain.Interfaces;
using Starks.Infrastructure.Data.DbContexts;
using Starks.Infrastructure.Data.Mapping;
using Starks.Infrastructure.Data.Repositories;

namespace Starks.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddStarks(this IServiceCollection services, string connectionString)
        {
            services.AddSqlServer(connectionString);
            services.AddAutoMapper();
            services.RegisterServices();
            return services;
        }

        private static IServiceCollection AddSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StarksDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new EntitiesProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // register application services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();

            // register data repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
