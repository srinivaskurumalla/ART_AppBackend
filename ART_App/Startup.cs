using ART_App.Models;
using ART_App.Repositories;
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
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ART_App
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ART_App", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
                });
            //configuration connection string information
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ARTConnection")));


            //Resolve DI

            //Accounts Model
            services.AddScoped<IRepositories<SignUpModel>, AccountsRepository>();
            services.AddScoped<IGetRepository<SignUpModel>, AccountsRepository>();

            //AccountsBRModel
            services.AddScoped<IRepositories<AccountsBRModel>, AccountsBRRepository>();
            services.AddScoped<IGetRepository<AccountsBRModel>, AccountsBRRepository>();

            //ProjectBRModel
            services.AddScoped<IRepositories<ProjectsBRModel>, ProjectsBRRepository>();
            services.AddScoped<IGetRepository<ProjectsBRModel>, ProjectsBRRepository>();

            //Domain Model
            services.AddScoped<IRepositories<DomainsModel>, DomainRepository>();
            services.AddScoped<IGetRepository<DomainsModel>, DomainRepository>();

            //MasterBRModel
            services.AddScoped<IRepositories<MasterBRModel>, MasterBRRespository>();
            services.AddScoped<IGetRepository<MasterBRModel>, MasterBRRespository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ART_App v1"));
            }

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
