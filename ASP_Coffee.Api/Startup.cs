using ASP_Coffe.Implementation.Commands.Create;
using ASP_Coffe.Implementation.Commands.Delete;
using ASP_Coffe.Implementation.Commands.Update;
using ASP_Coffe.Implementation.Email;
using ASP_Coffe.Implementation.Logging;
using ASP_Coffe.Implementation.Queries;
using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Api.Core;
using ASP_Coffee.Application;
using ASP_Coffee.Application.Interfaces;
using ASP_Coffee.Application.Interfaces.Email;
using ASP_Coffee.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Api
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
            var appSettings = new SettingsApp();

            Configuration.Bind(appSettings);

            services.AddControllers();

            services.AddDbContext<Coffee_Context>();
            services.AddTransient<UseCase>();
            services.AddTransient<GetBeans>();
            services.AddTransient<CreateBean>();
            services.AddTransient<CreateBeanValidator>();
            services.AddTransient<UpdateBean>();
            services.AddTransient<UpdateBeanValidator>();
            services.AddTransient<DeleteBean>();
            services.AddTransient<GetOrigins>();
            services.AddTransient<CreateOrigin>();
            services.AddTransient<CreateOriginValidator>();
            services.AddTransient<UpdateOrigin>();
            services.AddTransient<UpdateOriginValidator>();
            services.AddTransient<DeleteOrigin>();
            services.AddTransient<GetAmounts>();
            services.AddTransient<CreateAmount>();
            services.AddTransient<CreateAmountValidator>();
            services.AddTransient<UpdateAmount>();
            services.AddTransient<UpdateAmountValidator>();
            services.AddTransient<DeleteAmount>();
            services.AddTransient<GetCoffee>();
            services.AddTransient<CreateCoffee>();
            services.AddTransient<CreateCoffeeValidator>();
            services.AddTransient<UpdateCoffee>();
            services.AddTransient<UpdateCoffeeValidator>();
            services.AddTransient<DeleteCoffee>();
            services.AddTransient<GetOrders>();
            services.AddTransient<CreateOrder>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<DeleteOrder>();
            services.AddTransient<GetUseCaseLogs>();
            services.AddTransient<CreateUser>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<IEmail>(x => new SenderEmail(appSettings.EmailFrom, appSettings.EmailPass));
            services.AddAutoMapper(typeof(GetOrigins).Assembly);
            services.AddHttpContextAccessor();

            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("UserData") == null)
                {
                    return new UnRegisteredActor();
                }

                var userString = user.FindFirst("UserData").Value;
                var userJwt = JsonConvert.DeserializeObject<UserJwt>(userString);

                return userJwt;
            });

            services.AddTransient<MenagerJwt>(x =>
            {
                var context = x.GetService<Coffee_Context>();

                return new MenagerJwt(context, appSettings.JwtIssuer, appSettings.JwtKeySecret);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtKeySecret)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP_Coffee.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP_Coffee.Api v1"));
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseStaticFiles();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
