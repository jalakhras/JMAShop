using JMAShop.Auth;
using JMAShop.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMAShop
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        private IConfigurationRoot _configurationSecrets;
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration) {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
            //_configurationSecrets = new ConfigurationBuilder()
            //    .SetBasePath(hostingEnvironment.ContentRootPath)
            //    .AddJsonFile("secrets.json")
            //    .Build();
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
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IItemReviewRepository, ItemReviewRepository>();

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
            app.UseDeveloperExceptionPage();//to add support to showing Exption in browser
            app.UseStatusCodePages();//to allow handel respons status code between 400 and 600
            app.UseStaticFiles();//to serve static File
            app.UseSession(); //to Enable session
            app.UseIdentity();
            //app.UseMvcWithDefaultRoute();

           
            app.UseMvc(routes =>
            {
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

            //app.UseGoogleAuthentication(new GoogleOptions
            //{
            //    ClientId = "51552343977-irjtvsc99t3g0a43vt1fut5ft6jv2ps3.apps.googleusercontent.com",
            //    ClientSecret = "in0g-ChBZUdp9-Jvb2UjchuM"
            //});
            var GoogelAuth = new GoogleOptions
            {
                ClientId = "51552343977-irjtvsc99t3g0a43vt1fut5ft6jv2ps3.apps.googleusercontent.com",
                ClientSecret = "in0g-ChBZUdp9-Jvb2UjchuM"
            };
          

        }
    }
}
