using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HelloWorldSvc
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
            // Register swagger and MVC services
            services
                .AddSwaggerGen(config =>
                {
                    config.SwaggerDoc(
                        "v1",
                        new Swashbuckle.AspNetCore.Swagger.Info
                        {
                            Title = "Hello World API",
                            Version = "v1"
                        });
                    config.UseReferencedDefinitionsForEnums();
                })
                .AddMvc()
                .AddJsonOptions(opt =>
                {
                    // Setting this to AUTO is required to ensure that derived types
                    // are serialized and deserialized properly.  Otherwise only the base
                    // type (the declared type - normally the base type) ends up being
                    // deserialized.  This MUST be done on both the calling and recieving
                    // end to ensure it works properly.                
                    opt.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                    opt.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

                })
                .AddControllersAsServices();

            // Add API Versioning
            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.ReportApiVersions = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Hello World API v1");
            });
        }
    }
}
