using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Td.Kylin.DataCache;
using Td.Kylin.EnumLibrary;
using Td.Kylin.WebApi;

namespace Td.Kylin.Cache.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            SqlProviderType sqlType = new Func<SqlProviderType>(() =>
            {
                string sqltype = Configuration["Data:SqlType"] ?? string.Empty;

                switch (sqltype.ToLower())
                {
                    case "npgsql":
                        return SqlProviderType.NpgSQL;
                    case "mssql":
                    default:
                        return SqlProviderType.SqlServer;
                }
            }).Invoke();

            string redisConn = Configuration["Redis:ConnectString"]; //Redis缓存服务器信息
            var sqlConn = Configuration["Data:DefaultConnection:ConnectionString"];

            //BASE WEBAPI
            app.UseKylinWebApi(Configuration["ServerId"], sqlConn, sqlType);

            //缓存
            app.UseDataCache(new CacheInjectionConfig
            {
                CacheItems = null,
                InitIfNull = true,
                KeepAlive = true,
                Level2CacheSeconds = 600,
                RedisConnectionString = redisConn,
                SqlConnectionString = sqlConn,
                SqlType = sqlType
            });

            app.UseMvc();
        }
    }
}
