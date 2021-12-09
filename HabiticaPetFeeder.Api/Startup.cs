using HabiticaPetFeeder.Api.Model;
using HabiticaPetFeeder.Logic;
using HabiticaPetFeeder.Logic.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api
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
            services.UseHabiticaPetFeederServiceLayer();

            RegisterUserInfoFromConfiguration(services);

            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HabiticaPetFeeder.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HabiticaPetFeeder.Api v1"));
            }

            app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterUserInfoFromConfiguration(IServiceCollection services)
        {
            var useSecretAuth = Configuration.GetValue<bool>("AllowAuthenticationFromAppSecrets");

            if (!useSecretAuth)
                return;

            var result = Configuration.GetSection("HabiticaApiCredentials").Get<UserApiAuthInfo>();

            if (result == null || string.IsNullOrEmpty(result.ApiUserId) || string.IsNullOrEmpty(result.ApiKey))
                return;

            services.Configure<SecretUserApiAuthInfo>((options) =>
            {
                options.ApiUserId = result.ApiUserId;
                options.ApiKey = result.ApiKey;
                options.UseSecretAuth = useSecretAuth;
            });
        }
    }
}
