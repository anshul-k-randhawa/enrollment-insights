using CourseEnrollment.Api.Extension;
using CourseEnrollment.Api.Services;
using CourseEnrollment.Infra.Data;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CourseEnrollment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            var settings = Configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddApplicationInsightsTelemetry();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "student enrollment", Version = "v1" });
            });

            services.AddBearerAuthentication(Configuration, settings.BearerTokenOptions);
            services.AddCosmosDb(settings.CosmosDb.Account, settings.CosmosDb.Key, settings.CosmosDb.DatabaseName);
            services.AddSingleton<IScheduleService, ScheduleService>();
            services.AddSingleton<IEnrollmentService, EnrollmentService>();
            services.AddSingleton<IEnrollmentRepository, EnrollmentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseGlobalErrorHandler();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "student enrollment v1"));
        }
    }
}
