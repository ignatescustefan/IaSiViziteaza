using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.Implementations;
using IaSiViziteaza.DAL.Abstraction;
using IaSiViziteaza.DAL.Implementations;
using IaSiViziteaza.DAL.ORC.Abstraction;
using IaSiViziteaza.DAL.ORC.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace IaSiViziteaza
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

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddScoped<IRepositoryORC, RepositoryORC>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IAttractionTypeBusiness, AttractionTypeBussines>();
            services.AddScoped<ILocationBusiness, LocationBusiness>();
            services.AddScoped<IAttractionBusiness, AttractionBusiness>();
            services.AddScoped<ICommentBusiness, CommentBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(buider => buider.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
