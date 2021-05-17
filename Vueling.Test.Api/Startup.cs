using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Data;
using Vueling.Test.Repository.Repository;
using Vueling.Test.Services;
using Vueling.Test.Services.Domain;

namespace Vueling.Test.Api
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
            services.AddControllers();
            services.AddSingleton<IConfiguration>(provider => Configuration);
            services.AddDbContext<VuelingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MDF")));
            services.AddScoped<IRatesService, RatesService>();
            services.AddScoped<IRatesRepository, RatesRepository>();
            services.AddScoped<Client.ClientBuilder.IHttpClient, HttpClient>();
            services.AddScoped<ITransactionsService, TransactionsService>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();
            services.AddScoped<IRatesDomain, RatesDomain>();
            services.AddScoped<ITransactionsDomain, TransactionDomain>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
