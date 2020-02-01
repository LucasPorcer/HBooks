using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HBooks.Domain.Services;
using HBooks.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HBooks.WebClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<HBooks.Infra.HBooksAPI.BookObject, HBooks.Domain.Entities.Book.BookObject>();
                //.ForMember(dest => dest.BookReleaseDate, m => m.MapFrom(a => a.BookReleaseDate.Value.DateTime));
                config.CreateMap<HBooks.Infra.HBooksAPI.ResponseObject, HBooks.Domain.Entities.Response.ResponseObject>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddSingleton(new Configs(_configuration.GetConnectionString("ApiUrl")));
            services.AddTransient<IBookService, BookService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Books}/{action=Index}/{id?}");
            });
        }
    }
}
