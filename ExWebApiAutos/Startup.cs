using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IServices;
using Application.Services;
using Domain;
using Domain.IRepositories;
using ExWebApiAutos.Model;

using ExWebApiAutos.Model.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ExWebApiAutos
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
            services.AddDbContext<ExWebApiAutosDbContext>(
                options => options.UseSqlServer(
                    Configuration["Data:ExWebApiAutos:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => 
            options.UseSqlServer(
                Configuration["Data:ExWebApiAutosIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            //Repositorios
            services.AddTransient<IMarcaRepository, EFMarcaRepository>();
            services.AddTransient<IAutoRepository, EFAutoRepository>();

            //Servicios
            services.AddTransient<IMarcaService, MarcaService>();
            services.AddTransient<IAutoService, AutoService>();

            services.AddSwaggerGen(c => 
            { c.SwaggerDoc("v1", new Info { Title = "ExWebApiAutosServices", Version = "v1" });
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(); app.UseSwaggerUI(c => 
            { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}
