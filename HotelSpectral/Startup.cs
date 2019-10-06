using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using HotelSpectral.Data;
using HotelSpectral.Domain.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace HotelSpectral
{
    //public class Startup
    //{
    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddRazorPages();
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }
    //        else
    //        {
    //            app.UseExceptionHandler("/Error");
    //            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //            app.UseHsts();
    //        }

    //        app.UseHttpsRedirection();
    //        app.UseStaticFiles();

    //        app.UseRouting();

    //        app.UseAuthorization();

    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapRazorPages();
    //        });
    //    }
    //}

    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration 
        /// </summary>
        public IConfiguration _config { get; }

        /// <summary>
        /// Environment setup ..
        /// </summary>
        public Microsoft.Extensions.Hosting.IHostingEnvironment _env { get; }
        /// <summary>
        /// Startup constructor .. 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="env"></param>


        public Startup(IConfiguration config, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase(_config);
            services.AddApplicationIdentity(_config);
            services.InitializeAppServices();

            //// configure jwt auth service ..
            services.ConfigureJwtAuthService(_config, _env);

            // Background service ..
             services.HangFireService(_config);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "HotelSpectral",
                    Description = "A simple platform for Hotel managment",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "HotelSpectral Inc.",
                        Email = "info@payajo.com",
                        Url = "http://HotelSpectral.com"
                    },
                    License = new License
                    {
                        Name = "Use under HotelSpectral Inc.",
                        Url = "https://HotelSpectral.com"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFile = "swagger.xml";
                Debug.Write(xmlFile);
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // configure services  ..
            services.ConfigureServices();

            services.AddMvc();

        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ILoggerFactory loggerFactory,
        IConfiguration configuration, HotelSpectralContext _context)
        {

            // Initialize db  event  . 
           // app.Initializedb(env);

            // log activities  .. 
            app.Logger(loggerFactory, configuration);



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                //{
                //  HotModuleReplacement = true
                //});
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseAntiforgeryTokens();

           // app.UseAuthentication();

            //app.UseExceptionHandler(builder =>
            //{
            //    builder.Run(
            //        async context =>
            //        {
            //            context.Response.ContentType = "application/json";
            //            var error = context.Features.Get<IExceptionHandlerFeature>();
            //            //var result = await context.Get(error.Error);
            //            //await context.Response.WriteAsync(result);
            //        });
            //});

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelSpectral portal");
                c.RoutePrefix = "swagger";
            });

            // context.Database.Migrate();

            // HangFire asp.net pipeline

            //DashboardOptions opts = new DashboardOptions
            //{
            //    Authorization = new[] { new CustomAuthorizeFilter() }
            //};

            // app.UseHangfireServer();

            //  app.UseHangfireDashboard("/jobs", opts);

            //BackgroundJob.Schedule(() => _hangFire.ResetTechDateJob(),
            //  TimeSpan.FromMinutes(double.Parse(_config["System:TechDays"])));

            //BackgroundJob.Schedule(() => _hangFire.DebitTechCustomerBalanceOnIsChargeableJob(),
            //  TimeSpan.FromMinutes(double.Parse(_config["System:SmsDays"])));

            // RecurringJob.AddOrUpdate(() => _hangFire.SendSmsHangFireNotification(), Cron.Daily);

            // RecurringJob.AddOrUpdate(() => _hangFire.WeeklySmsDateResetJob(), Cron.Weekly);

            // BackgroundJob.Schedule(() => _hangFire.PushSms(), TimeSpan.FromSeconds(10));

            // InitializeDatabase(app);

            //if (env.IsDevelopment())
            //    PayAjoSeeder.Seed(_context);

            //app.Use(async (context, next) =>
            //{
            //    if ((context.Response.StatusCode == 404 || !Path.HasExtension(context.Request.Path.Value))
            //                                     && !context.Request.Path.Value.StartsWith("/api/", StringComparison.CurrentCulture))
            //    {
            //        context.Request.Path = "/index.html";
            //    }

            //    await next.Invoke();
            //});




            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseMvc();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                //  scope.ServiceProvider.GetRequiredService<HotelSpectralContext>().Database.Migrate();
            }
        }
    }
}