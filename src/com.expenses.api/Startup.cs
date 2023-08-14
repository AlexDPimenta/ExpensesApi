using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using com.expenses.datacomunication.Mapper.AuthLogin;
using com.expenses.infra.IOC;
using com.expenses.service.IOC;
using com.expenses.tools;
using com.expenses.tools.DomainExceptions;

namespace TesteVibbra
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
            services.AddScoped<NotificationContext>();
            services.AddMvc(options => options.Filters.Add<NotificationFilter>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteVibbra", Version = "v1" });
            });
            
            services.AddInfra(Configuration);
            services.AddServices();
            #region Jwt
            services.AddAutoMapper(typeof(AuthLoginRequestDtoToLoginModel));
            var key = Encoding.ASCII.GetBytes(TokenSettings.TokenSecret);            
            services.AddAuthentication((JwtBearerDefaults.AuthenticationScheme))
            .AddJwtBearer(x =>
            {                
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,                    
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = TokenSettings.Issuer,
                    ValidAudience = TokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                };
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteVibbra v1"));
            }


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
