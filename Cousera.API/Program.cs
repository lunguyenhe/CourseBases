using Cousera.Infrastructure.Configurations;
using Cousera.Infrastructure.DI.Extensions;
using Cousera.Infrastructure.DI.Options;
namespace Cousera.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //PERISTENCE LAYER
            builder.Services.ConfigureSqlServerRetryOptionPersistence(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
            builder.Services.AddSqlServerPersistence();
           // builder.Services.AddRepositories();
            var app = builder.Build();

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
        }
    }
}
