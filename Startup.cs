using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using DemoExperionWebAPI_1.Models;
using DemoExperionWebAPI_1.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace DemoExperionWebAPI_1
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
            //all services are kept here
            services.AddControllers();

            //connection string for datbase inject as dependency 
            services.AddDbContext<DemoExperionDBContext>(db =>
            db.UseSqlServer(Configuration.GetConnectionString("EmpDBConnection")));

            //add dependency injection for employee repository
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            //adding services for newtonsoft
            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            //resolve serialize error and refrence loop
            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            //register JWT authentication schema
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //configure authentication scheme with jwt bearer options
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                }
                );

            //Json --resolver
            services.AddControllers()
                .AddNewtonsoftJson(Options =>
                {
                    Options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
            

            //enable Cors
            services.AddCors();
            //services.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            //Cors settings
            app.UseCors(Options =>
                Options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configure authentication : make authentication available for application
            app.UseAuthentication();

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
