using ARM.Movies.Common.Interfaces;
using ARM.Movies.DataAccess.Repositories;
using ARM.Movies.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ARM.Movies.DataAccess.Context;
using ARM.Movies.Api.CustomExceptions;

namespace ARM.Movies.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config.txt"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: Get connection string from config
            var connection = @"Server=.;Database=ARMMovie-DB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<IMovieContext, MovieContext>
                (options => options.UseSqlServer(connection));
            services.AddScoped<IMovieRepository, MovieRepository>();            
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ARM.Movies.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager loggerManager)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ARM.Movies.Api v1"));
            }

            //custom exception handler
            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
