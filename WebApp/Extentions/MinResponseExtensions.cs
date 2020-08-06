﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO.Compression;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore3;
using WebMarkupMin.NUglify;

namespace WebApp.Extentions {

  public static class MinResponseExtensions {
    /// <summary>
    ///     Add service to mini and compress HTML, XML, CSS, JS
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddMinResponse(this IServiceCollection services) {
      services
          // Global
          .AddWebMarkupMin(options => {
            options.MaxResponseSize = -1; // Allow min all size

            options.AllowMinificationInDevelopmentEnvironment = true;
            options.AllowCompressionInDevelopmentEnvironment = true;

            options.DisablePoweredByHttpHeaders = true;
            options.DisableCompression = false; // false
            options.DisableMinification = false;// false
          })
          // HTML, CSS, JS Mini
          .AddHtmlMinification(options => {
            options.MinificationSettings.MinifyEmbeddedCssCode = true;
            options.MinificationSettings.RemoveRedundantAttributes = false;
            options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
            options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
            options.MinificationSettings.RemoveOptionalEndTags = false; // [Important] Don't enable/true this

            options.CssMinifierFactory = new NUglifyCssMinifierFactory();
            options.JsMinifierFactory = new NUglifyJsMinifierFactory();
          })
          // XML Mini
          .AddXmlMinification(options => {
            options.MinificationSettings.CollapseTagsWithoutContent = true;
          })
          // Compress
          .AddHttpCompression(options => {
            options.CompressorFactories = new List<ICompressorFactory>
                  {
                        new DeflateCompressorFactory(new DeflateCompressionSettings
                        {
                            Level = CompressionLevel.Fastest
                        }),
                        new GZipCompressorFactory(new GZipCompressionSettings
                        {
                            Level = CompressionLevel.Fastest
                        })
              };
          });

      return services;
    }

    public static IApplicationBuilder UseMinResponse(this IApplicationBuilder app) {
      app.UseWebMarkupMin();
      return app;
    }
  }
}