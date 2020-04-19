using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace Redirect
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        static string BaseUrl = "https://www.maacpiash.com";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IShortcutService, ShortcutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(app))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(app);
                Console.WriteLine("{0}={1}", name, value);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DotNetEnv.Env.Load("../.env");
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => RedirectRoUrl(context, BaseUrl));
                endpoints.MapGet("/{pageKey}", context =>
                {
                    var pageKey = context.Request.Path.ToString().Split('/')[1];
                    if (string.IsNullOrEmpty(pageKey))
                        return RedirectRoUrl(context, BaseUrl);
                    var service = app.ApplicationServices.GetRequiredService<IShortcutService>();
                    var redirection = service.Get(pageKey);
                    string url = redirection?.RealUrl ?? BaseUrl;
                    return RedirectRoUrl(context, url);
                });
            });
        }

        Task RedirectRoUrl(HttpContext context, string url) =>
            Task.Factory.StartNew(() => context.Response.Redirect(url));
    }
}
