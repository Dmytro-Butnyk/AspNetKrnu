using Application.Options;
using Data;
using Data.Repositories;
using Data.Repositories.Shared;
using Domain.Interfaces.DbRepositoryInterfaces;
using Domain.Interfaces.DbRepositoryInterfaces.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace SportsBookingSystem.Extentions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString("LocalConnectionString");
        builder.Services.AddDbContext<SportsBookDbContext>(options =>
            options.UseNpgsql(connectionString));

        return builder;
    }
    public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        builder.Services.AddScoped<ISportFieldRepository, SportFieldRepository>();
        builder.Services.AddScoped<ISportFieldTypeRepository, SportFieldTypeRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        return builder;
    }
    public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
        builder.Services.Configure<Application.Options.CookieOptions>(builder.Configuration.GetSection("CookieOptions"));
        
        return builder;
    }
    public static WebApplicationBuilder AddJwtBearer(this WebApplicationBuilder builder)
    {
        JwtOptions? jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();

        if (jwtOptions == null)
        {
            throw new KeyNotFoundException("JwtOptions are not configured correctly.");
        }

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.ISSUER,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.AUDIENCE,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = jwtOptions.GetKey()
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        string? token = context.Request.Cookies["Token"];
                        if (!string.IsNullOrEmpty(token))
                        {
                            context.Token = token;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

        return builder;
    }
}