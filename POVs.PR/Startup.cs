using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using POVs.BL.Interface;
using POVs.BL.Mapper;
using POVs.BL.Repository;
using POVs.DAL.Database;
using POVs.PR.Language;
using System.Collections.Generic;
using System.Globalization;

namespace POVs.PR
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
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver())
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization(
                        option =>
                        {
                            option.DataAnnotationLocalizerProvider = (type, factory) =>  factory.Create(typeof(ProjectResources));
                        }
                        
                     );
               
            //connection string
            var con = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(con));

            // Auto Mapper
            services.AddAutoMapper(map => map.AddProfile(new DomainProfile()));

            services.AddScoped<IDepartmentRep,DepartmentRep>();
            services.AddScoped<IEmployeeRep,EmployeeRep>();
            services.AddScoped<ICountryRep,CountryRep>();
            services.AddScoped<ICityRep,CityRep>();
            services.AddScoped<IDistrictRep,DistrictRep>();


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
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var supportedCulture = new[] { new CultureInfo("ar-EG"),new CultureInfo("en-US") };
            app.UseRequestLocalization(
                new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("en-US"),
                    SupportedCultures = supportedCulture,
                    SupportedUICultures = supportedCulture,
                    RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                        new QueryStringRequestCultureProvider(),
                        new CookieRequestCultureProvider()
                    }
                }
             );
        }
    }
}
