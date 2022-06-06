using AutoMapper;
using BuyRequest_Application.Applications;
using BuyRequest_Application.Interface;
using BuyRequest_Application.Service;
using BuyRequest_Application.Service.Interface;
using BuyRequestData.Context;
using BuyRequestData.Repository;
using BuyRequestData.Repository.Interface;
using BuyRequestDomain.Mapping;
using CashBook_API_Client.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Producer;

namespace BuyRequest_Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuyRequest_Api", Version = "v1" });
            });

            services.AddDbContext<BuyRequestContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCashBookConfiguration(Configuration);
            services.AddCashBookProducerConfiguration(Configuration);

            services.AddScoped<IBuyRequestApplication, BuyRequestApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();

            services.AddScoped<IBuyRequestService, BuyRequestService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IBuyRequestRepository, BuyRequestRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //  services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuyRequest_Api v1"));

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