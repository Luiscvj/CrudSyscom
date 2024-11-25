﻿using AspNetCoreRateLimit;
using LibraryCrud.Application.UnitOfWork;
using LibraryCrud.Domain.Interfaces;

namespace LibraryCrud.Api.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            //se configura los cors de mi api para mantener la seguridad de la api
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .SetIsOriginAllowed(origin =>
                            {
                                if (string.IsNullOrWhiteSpace(origin)) return false;
                                // Only add this to allow testing with localhost, remove this line in production!
                                if (origin.ToLower().StartsWith("http://localhost")) return true;
                                // Insert your production domain here.
                                if (origin.ToLower().StartsWith("https://dev.mydomain.com")) return true;
                                return false;
                            });

                });
            });

        }


        public static void AddApplicationServices(this IServiceCollection services)
        {
            //
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        

        }
        //Se configura el limite de veces que se puede llamar un endpoint
        public static void ConfigureRateLimit(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>()
                {
                    new(){
                        Endpoint = "*",//From any Http request
                        Period = "10s",//Period of time to  refresh the rule 
                        Limit = 50// Allowed request times

                    }

                };
            });
        }
    }
}
