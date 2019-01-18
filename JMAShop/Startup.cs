using JMAShop.Auth;
using JMAShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMAShop
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
       

        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration) {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
           
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
                  .AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IItemReviewRepository, ItemReviewRepository>();


            //specify options for the anti forgery here
            services.AddAntiforgery(opts => { opts.RequireSsl = true; });

            //anti forgery as global filter
            services.AddMvc(options =>
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddMvc();
            //Claims-based
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteItem", policy => policy.RequireClaim("Delete Item", "Delete Item"));
                options.AddPolicy("AddItem", policy => policy.RequireClaim("Add Item", "Add Item"));
                options.AddPolicy("MinimumOrderAge", policy => policy.Requirements.Add(new MinimumOrderAgeRequirement(18)));

            });
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //Diagnostics
            //app.UseWelcomePage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/AppException");
            }


            app.UseDeveloperExceptionPage();//to add support to showing Exption in browser
            app.UseStatusCodePages();//to allow handel respons status code between 400 and 600
            app.UseStaticFiles();//to serve static File
            app.UseSession(); //to Enable session
            app.UseIdentity();
            //app.UseMvcWithDefaultRoute();

           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
            name: "areas",
            template: "{area:exists}/{controller=Home}/{action=Index}"
          );
                routes.MapRoute(
                  name: "categoryfilter",
                  template: "Item/{action}/{category?}",
                  defaults: new { Controller = "Item", action = "List" });

                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");


            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbcontext = serviceScope.ServiceProvider.GetService<AppDbContext>();
                DbInitializer.Seed(dbcontext);
            }

           

        }
    }
}
