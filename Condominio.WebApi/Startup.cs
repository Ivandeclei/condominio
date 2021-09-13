using AutoMapper;
using Condominio.Application.Microsoft.Extensions.DependencyInjection;
using Condomino.DbAdapter;
using Condomino.DbAdapter.DbAdapterConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Condominio.WebApi
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
       
            services.AddAutoMapper(
                typeof(WebApiMapperProfile),
                typeof(CondominioAdapterMapperProfile),
                typeof(IMapper));

            services.AddApplication();

            var connectionString = new DbAdapterConfiguration
            {
                ConnectionString = Configuration.GetSection("DbAdapterConfiguration:ConnectionString").Value
            };

            services.AddDbAdapter(connectionString);
           
            services.AddSwaggerGen();
            services.AddMvcCore();
            services.AddControllers();
        
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Condominio API");
                c.RoutePrefix = string.Empty;
            }) ; 
           

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
                //  endpoints.MapRazorPages();
            });
        }
    }
}
