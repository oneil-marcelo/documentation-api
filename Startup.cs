using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DocumentationApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DocumentationApi
{
    #pragma warning disable CS1591    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Game API",
                    Version = "v1",
                    Description = "O projeto Game API tem o objetivo de estudar e a demonstrar de maneira objetiva, \ncomo documentar API usando o framework Swagger.",
                    Contact = new Contact {
                        Name = "Sobre o Autor",
                        Url = "https://www.linkedin.com/in/oneil-marcelo/",
                    },
                    License = new License {
                        Name = "Código Fonte GitHub",
                        Url = "https://www.github.com/oneil-marcelo/documentation-api"
                    }

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger(o => 
                {
                    o.RouteTemplate = "docs/{documentName}/docs.json";
                });

                app.UseSwaggerUI(c =>
                {
                    
                    c.InjectStylesheet("/swagger-ui/custom.css");
                    c.InjectJavascript("/swagger-ui/custom.js");
                    c.RoutePrefix = "docs";
                    c.SwaggerEndpoint("/docs/v1/docs.json", "Game API");
                });
            }

            app.UseStaticFiles();
            
            app.UseMvc();

            app.UseSwagger(o => 
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });

            app.UseSwaggerUI(c =>
            {
                
                c.InjectStylesheet("/api/swagger-ui/custom.css");
                c.InjectJavascript("/api/swagger-ui/custom.js");
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("/api/docs/v1/docs.json", "Game API");
            });
        }
    }
}
