﻿using ClientsMicroservice.Data.Context;
using ClientsMicroservice.Data.Repository;
using ClientsMicroservice.Services;
using ClientsMicroservice.Services.Interfaces;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared;
using RealEstate.Shared.Data.Repository;

namespace ClientsMicroservice.Properties
{
    public static class ClientsStartupExtensions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IUserService, UserService>();

            // DbContexts using pooling for better performance
            services.AddDbContextPool<UsersDBContext>(options => 
                options.UseNpgsql(GlobalConnectionStrings.Clients_MicroDB_Connection));

            services.AddDbContextPool<ClientsDBContext>(options =>
                options.UseNpgsql(GlobalConnectionStrings.Clients_MicroDB_Connection));

            // Repositories
            services.AddScoped<IClientsDbRepository, ClientsDbRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }

        public static IServiceCollection AddKeycloakClientConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            var keycloakAdminOptions = configuration
                .GetSection(KeycloakAdminClientOptions.Section)
                .Get<KeycloakAdminClientOptions>();

            var keycloakProtectionOptions = configuration
                .GetSection(KeycloakProtectionClientOptions.Section)
                .Get<KeycloakProtectionClientOptions>();

            // requires confidential client
            services.AddKeycloakAdminHttpClient(keycloakAdminOptions);

            // based on token forwarding HttpClient middleware and IHttpContextAccessor
            services.AddKeycloakProtectionHttpClient(keycloakProtectionOptions);


            return services;
        }
    }
}
