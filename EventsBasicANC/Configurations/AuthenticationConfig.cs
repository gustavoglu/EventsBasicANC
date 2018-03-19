using EventsBasicANC.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace EventsBasicANC.Configurations
{
    public class AuthenticationConfig
    {
        private const string SecretKey = "BaseProjectAspNetCoreSercretKey";
        private static readonly SymmetricSecurityKey _signKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public static void ConfigureJwtAuthService(IServiceCollection services, IConfigurationSection jwtAppSettingOptions)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtTokenOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.Configure<JwtTokenOptions>(options =>
                {
                    options.Issuer = jwtAppSettingOptions[nameof(JwtTokenOptions.Issuer)];
                    options.Audience = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)];
                    options.SigningCredentials = new SigningCredentials(_signKey, SecurityAlgorithms.HmacSha256);
                });

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o => { o.TokenValidationParameters = tokenValidationParameters; });
        }
    }
}
