
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartCertify.Infrastructure;

namespace SmartCertify.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Configuring Services - Start
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SmartCertifyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"),
                providerOptions => providerOptions.EnableRetryOnFailure());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            #endregion Configuring Services - End

            #region Configuring Middleware - Start
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwaggerUi(options =>
                {
                    options.DocumentPath = "openapi/v1.json";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            #endregion Configuring Middleware - End
        }
    }
}
