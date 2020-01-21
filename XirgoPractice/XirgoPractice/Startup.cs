using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XirgoPractice.DataManagement;
using XirgoPractice.DataManagement.BaseRepository;
using XirgoPractice.DataManagement.BaseRepository.Interfaces;
using XirgoPractice.Hub;
using XirgoPractice.Modeling;
using XirgoPractice.Services;
using XirgoPractice.Services.Interfaces;

namespace XirgoPractice
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });

            var mapperConfiguration = new AutoMapper.MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MapperConfiguration());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<ICarsService, CarsService>();
            services.AddScoped<IDeviceRecordsService, DeviceRecordsService>();
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<DbContext, DatabaseContext>();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseSignalR(routes => { routes.MapHub<TrackingHub>("/trackinghub"); });
            app.UseMvc();
        }
    }
}
