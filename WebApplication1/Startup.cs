using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BinaryNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using BinaryNetCoreApp.Services;
using System.IO;
using BinaryNetCoreApp.Logger;

namespace BinaryNetCoreApp
{
    public class Startup
    { 
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISimpleModelService, SimpleModelService>();

            string con = "Server=(localdb)\\mssqllocaldb;Database=SimpleModels;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<SimpleModelContext>(options => options.UseSqlServer(con));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SimpleModelContext context, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            SimpleModelService service = new SimpleModelService(context);
            DbInitializer dbinitializer = new DbInitializer(service);
            dbinitializer.Initialize();
            app.UseMvc();
        }
    }
}
