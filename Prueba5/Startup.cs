using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoBll;
using BancoBll.Interfaces;
using BancoDal;
using BancoDal.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Modelo;

namespace Prueba5
{
  public class Startup
  {

    readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddDbContext<BancoContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      //services.AddScoped<BancoContext>();
      services.AddScoped<IBancoContext>(provider => provider.GetService<BancoContext>());

      services.AddScoped<ICuentaDal, CuentasDal>();
      services.AddScoped<ICuentaBll, CuentaBll>();
      services.AddScoped<IPersonaBll, PersonaBll>();
      services.AddScoped<IPersonaDal, PersonaDal>();


      services.AddIdentity<User, Roles>(options =>
            {
              options.Password.RequireDigit = false;
              options.Password.RequiredLength = 4;
              options.Password.RequiredUniqueChars = 0;
              options.Password.RequireLowercase = false;
              options.Password.RequireUppercase = false;
              options.Password.RequireNonAlphanumeric = false;
              options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<BancoContext>()
            .AddDefaultTokenProviders();

      services.AddSwaggerGen();


      //var urlPermitidas = Configuration.GetSection("App:UrlPermitidas").Get<List<string>>();
      services.AddCors(options =>
      {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          builder =>
                          {
                            builder.WithOrigins("*")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod().AllowAnyOrigin();
                          });
      });

      //Activar Authorization all api
      //services.AddControllers(
      //     option =>
      //     {
      //       var policy = new AuthorizationPolicyBuilder()
      //                 .RequireAuthenticatedUser()
      //                 .Build();
      //       option.Filters.Add(new AuthorizeFilter(policy));
      //             //option.Filters.Add(typeof(CustomExceptionFilterAttribute));
      //           }
      //);
      //Fin activar Authorization all api

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger(c =>
      {
        c.SerializeAsV2 = true;
      });
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

  

      app.UseCors(MyAllowSpecificOrigins);

      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "");
        c.RoutePrefix = string.Empty;
      });

      app.UseRouting();

      app.UseAuthentication();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
