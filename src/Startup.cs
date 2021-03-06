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
            services.AddRazorPages();
            services.AddSingleton<IShortcutService, ShortcutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                endpoints.MapGet("/", context =>
                    Task.Run(() => context.Response.Redirect(BaseUrl))
                );
                endpoints.MapRazorPages();
                endpoints.MapGet("/{pageKey}", context =>
                {
                    var pageKey = context.Request.Path.ToString().Split('/')[1];
                    if (string.IsNullOrEmpty(pageKey))
                        return Task.Run(() => context.Response.Redirect(BaseUrl));
                    var service = app.ApplicationServices.GetRequiredService<IShortcutService>();
                    var redirection = service.Get(pageKey);
                    return Task.Run(() => context.Response.Redirect(redirection?.RealUrl ?? BaseUrl));
                });
            });
        }
    }
}
