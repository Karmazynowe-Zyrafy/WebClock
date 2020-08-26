using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebClock.Models;
using WebClock.Models.EfRepository;

namespace WebClock
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder => { builder.WithOrigins("http://localhost:4200"); });
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder => { builder.WithOrigins("https://clkocindevops.azurewebsites.net"); });
            });
            services.AddControllers();

            SetupRepository(services);
        }

        protected virtual void SetupRepository(IServiceCollection services)
        {
            services.AddDbContext<ClockInOutContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddScoped(typeof(IRepository), typeof(EfRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}