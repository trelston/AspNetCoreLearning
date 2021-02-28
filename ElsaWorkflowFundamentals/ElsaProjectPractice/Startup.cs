using Elsa.Activities.Email.Extensions;
using Elsa.Activities.Http.Extensions;
using Elsa.Activities.Timers.Extensions;
using Elsa.Dashboard.Extensions;
using Elsa.Persistence.EntityFrameworkCore.DbContexts;
using Elsa.Persistence.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElsaProjectPractice
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
            services.AddControllersWithViews();

            //Required services for Elsa to work. Registers things like `IWorkflowInvoker`
            services.AddElsa(elsa => elsa.AddEntityFrameworkStores<SqliteContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Sqlite"))));

            //Registers necessary service to handle HTTP requests
            services.AddHttpActivities(options => options.Bind(Configuration.GetSection("Elsa:Http")));
            services.AddEmailActivities(options => options.Bind(Configuration.GetSection("Elsa:Smtp")));
            services.AddTimerActivities(options => options.Bind(Configuration.GetSection("Elsa:Timers")));

            services.AddElsaDashboard();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Register necessary ASP.NET core middleware that triggers workflows containing HTTP activities


            app.UseStaticFiles();
            app.UseHttpActivities();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}