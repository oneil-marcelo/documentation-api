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

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "Documentando API com o Swagger.",
                    TermsOfService = "None",
                    Contact = new Contact {
                        Name = "Marcelo O'neil",
                        Email = "email@email.com.br",
                        Url = "https://www.github.com/oneilmarcelo"
                    },
                    License = new License { 
                        Name = "User Under XPTO",
                        Url = "https://www.github.com/oneilmarcelo"
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
            }

            app.UseStaticFiles();
            
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
