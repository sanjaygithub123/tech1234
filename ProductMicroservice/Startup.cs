using ProductMicroservice.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Filters;
using ProductMicroservice.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProductMicroservice
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      var secret = Configuration.GetSection("JwtConfig").GetSection("secret").Value;  
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession();
        //services.AddTokenAuthentication(Configuration);
        //uncomment above line to enable JWT tokn authentication and comment google authentication
         services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
            options.LoginPath = "/api/account"; // Must be lowercase
        })
        .AddGoogle(options =>
        {
            options.ClientId = "687625044779-8u21a9al83hn97ljh0efqdulphusn5jp.apps.googleusercontent.com";
            options.ClientSecret = "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";
        });
        services.AddSwaggerGen();  
         services.AddMvc(options =>
            {
              options.Filters.Add(new GlobalExceptionFilter());
               options.EnableEndpointRouting = false;
            });
     // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      //services.AddDbContext<ProductContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ProductDB")));
      services.AddTransient<IProductRepository, ProductRepository>();

      
 
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
   
      if (env.IsDevelopment())
      {
          app.UseSwagger();  
          app.UseSwaggerUI(c =>  
          {  
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");  
          }); 
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }
      app.UseSession();
      app.UseAuthentication();  
      app.UseAuthorization();  
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
