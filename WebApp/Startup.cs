using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using WebApp.Application.Interfaces;
using WebApp.Application.Repositories;
using WebApp.Application.Services;
using WebApp.Data.DBContext;
using WebApp.Data.Entity.Billing;
using WebApp.Extentions;
using WebApp.Models.Entities;

namespace WebApp {

  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddEntityFrameworkSqlServer();
      services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
             o => o.MigrationsAssembly("WebApp.Data"))); //, ServiceLifetime.Transient);
      services.AddDbContext<BillingDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("BillingConnection"),
             o => o.MigrationsAssembly("WebApp.Data"))); //, ServiceLifetime.Transient);

      services.AddAuthentication(sharedOptions => {
        sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        sharedOptions.DefaultChallengeScheme = WsFederationDefaults.AuthenticationScheme;
        //sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      }).AddWsFederation(options => {
        options.Wtrealm = "https://localhost:44397";
        options.MetadataAddress = "https://login.vntt.com.vn/FederationMetadata/2007-06/FederationMetadata.xml";

        //options.Events.OnRedirectToIdentityProvider = ctx => {
        //  ctx.ProtocolMessage.Wct = DateTimeOffset.UtcNow.ToString();
        //  return Task.CompletedTask;
        //};
        //options.SignOutWreply = "https://login.vntt.com.vn/adfs/ls?wa=wsignoutcleanup1.0";
        //options.Wreply = "https://localhost:44333/account/roles";
      }).AddCookie();
      services.AddAutoMapper(typeof(Startup));

      // Not Active
      services.AddHttpContextAccessor();
      services.AddTransient<IHelperService, HelperService>();
      services.AddTransient<IActiveService<CM_Active>, ActiveService<CM_Active>>();
      services.AddTransient<ICommonService, CommonService>();
      // Active
      services.AddTransient<IClassService, ClassService>();
      services.AddTransient<IActiveService<ED_Class>, ActiveService<ED_Class>>();
      services.AddTransient<IImageService, ImageService>();
      services.AddTransient<IActiveService<CM_Image>, ActiveService<CM_Image>>();
      services.AddTransient<IPermissionService, PermissionService>();
      services.AddTransient<IActiveService<CM_Permission>, ActiveService<CM_Permission>>();
      services.AddTransient<IDayService, DayService>();
      services.AddTransient<IActiveService<BiDays>, ActiveService<BiDays>>();

      //services.AddTransient<SequentialGuidValueGenerator>();

      // services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

      services.AddResponseCaching();

      services.AddResponseCompression(); // 15/07/2020
      services.Configure<GzipCompressionProviderOptions>(options => {  // 15/07/2020
        options.Level = CompressionLevel.Fastest;
      });

      services.AddControllersWithViews().AddRazorOptions(
        options => {// Add custom location to view search location
          options.ViewLocationFormats.Add("/Pages/{0}.cshtml");
          options.ViewLocationFormats.Add("/Pages/{1}/{0}.cshtml");
          options.ViewLocationFormats.Add("/Views/Commons/{0}.cshtml");
          options.ViewLocationFormats.Add("/Views/Commons/{1}/{0}.cshtml");
          options.ViewLocationFormats.Add("/Views/Billings/{1}/{0}.cshtml");
        });
      services.AddRazorPages();

      services.Configure<RequestLocalizationOptions>(options => {
        options.DefaultRequestCulture = new RequestCulture("vi-VN");
      });

      //services.AddMemoryCache();// Use IMemoryCache if not run
      services.AddMinResponse();
      services.AddDistributedMemoryCache();

      // If using Kestrel:
      //services.Configure<KestrelServerOptions>(options =>
      //{
      //  options.AllowSynchronousIO = true;
      //});
      // If using IIS:
      services.Configure<IISServerOptions>(options => {
        options.AllowSynchronousIO = true;
      });
      //services.AddHttpContextAccessor(); // Ngon add, default run
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Billing API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
          Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
      });
      services.AddRouting(options => options.LowercaseUrls = true);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
      ILoggerFactory loggerFactory) {
      loggerFactory.AddFile("Logs/api-{Date}.txt");
      if(env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage(); // Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
      } else {
        app.UseExceptionHandler("/home/error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //app.UseHsts();
      }
      app.UseDeveloperExceptionPage();
      app.UseDatabaseErrorPage();

      app.UseHttpsRedirection();
      // Use static files
      app.UseStaticFiles(new StaticFileOptions {
        OnPrepareResponse = ctx => {
          // Cache static files for 30 days
          ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
          ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(365).ToString("R", CultureInfo.InvariantCulture));
        }
      });

      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Billing API V1");
      });

      app.UseResponseCompression(); // New add 21/04/2020

      app.UseRouting();

      app.UseMinResponse();

      app.UseAuthentication();
      app.UseAuthorization();

      //app.UseStatusCodePagesWithRedirects("~/home/error/{0}");
      app.UseRequestLocalization();

      app.UseResponseCaching();

      //app.Use(async (context, next) => {
      //  context.Response.GetTypedHeaders().CacheControl =
      //      new Microsoft.Net.Http.Headers.CacheControlHeaderValue() {
      //        Public = true,
      //        MaxAge = TimeSpan.FromSeconds(1000)
      //      };
      //  context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
      //      new string[] { "Accept-Encoding" };
      //  await next();
      //});
      app.UseEndpoints(endpoints => {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}