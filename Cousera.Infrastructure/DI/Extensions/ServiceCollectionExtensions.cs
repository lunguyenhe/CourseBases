using Cousera.Domain.Entities.Identity;
using Cousera.Infrastructure.Context;
using Cousera.Infrastructure.DI.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Infrastructure.DI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSqlServerPersistence(this IServiceCollection services)
    {
        services.AddDbContextPool<DbContext, ApplicationDBContext>((provider, builder) =>
        {
            //var auditableInterceptor = provider.GetService<UpdateAuditxableEntitiesInterceptor>();

            var configuration = provider.GetService<IConfiguration>();
            var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();


            builder
            .EnableDetailedErrors(true)
            .EnableSensitiveDataLogging(true)
            .UseLazyLoadingProxies(true)
            .UseSqlServer(
                connectionString: configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: optionsBuiler
                =>
                optionsBuiler.ExecutionStrategy(
                    dependencies => new SqlServerRetryingExecutionStrategy(
                        dependencies: dependencies,
                     maxRetryCount: options.CurrentValue.MaxRetryCount,
                     maxRetryDelay: options.CurrentValue.MaxRetryDelay,
                        errorNumbersToAdd: options.CurrentValue.ErrorNumbersToAdd)
                    ).MigrationsAssembly(typeof(ApplicationDBContext).Assembly.GetName().Name))
            .AddInterceptors();//auditableInterceptor);
        });

        services.AddIdentityCore<AppUser>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);


            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
            //options.Password.RequireDigit = false;
            //options.Password.RequireLowercase = false;
            //options.Password.RequireUppercase = false;
            //options.Password.RequireNonAlphanumeric = false;
            //options.Password.RequiredLength = 6;
            //options.User.RequireUniqueEmail = true;
        }).AddRoles<AppRole>()
        .AddEntityFrameworkStores<ApplicationDBContext>();

        var passwordValidatorOptions =
            services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<PasswordValidatorOptions>>;
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;


            //Enalbing Email Confirmation
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;

        });
    }
    public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptionPersistence(this IServiceCollection services, IConfiguration section)
     => services.AddOptions<SqlServerRetryOptions>()
      .Bind(section).ValidateDataAnnotations().ValidateOnStart();
}
