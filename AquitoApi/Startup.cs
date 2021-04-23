using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using AquitoApi.Services;
using AquitoApi.Entities;
using AquitoApi.Helpers.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;

namespace AquitoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            IdentityModelEventSource.ShowPII = true; //To show detail of error and see the problem

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<d2bc1ckqeusvkjContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Dbconnection")));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<Account>(Configuration.GetSection("Cloudinary"));

            // Agregar Identity
            services.AddIdentity<Useraquito, Roleaquito>(
                options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<d2bc1ckqeusvkjContext>()
            .AddDefaultTokenProviders();

            // Configurar Autenticacion con el standard JwtBearer
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                byte[] key = Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"]);

                options.Authority = Configuration["AppSettings:Authority"];
                options.Audience = Configuration["AppSettings:Audience"];
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });


            services.AddHttpContextAccessor();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(opciones => opciones.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();


            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
