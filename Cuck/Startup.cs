using System;

using Cuck.Data;
using Cuck.Models;
using Cuck.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cuck
{
    public class Startup
    {
        public string ProdDb;
        public string DevDb;
        public string Stage;





        public Startup( IConfiguration configuration ) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            ProdDb = Environment.GetEnvironmentVariable ( "ProdDb" );
            DevDb = Configuration["DevDb"];
            Stage = Environment.GetEnvironmentVariable ( "ASPNETCORE_ENVIRONMENT" );


            if ( Stage == "Development" )
            {

                services.AddDbContext<ApplicationDbContext> ( options =>
                  options.UseSqlServer ( DevDb ) );
                services.AddDbContext<CuckContext> ( options =>
                  options.UseSqlServer ( DevDb ) );

            }
            else
            {
                services.AddDbContext<ApplicationDbContext> ( options =>
                  options.UseSqlServer ( ProdDb ) );
                services.AddDbContext<ApplicationDbContext> ( options =>
                  options.UseSqlServer ( ProdDb ) );
            }

            services.AddIdentity<ApplicationUser,IdentityRole> ( )
                .AddEntityFrameworkStores<ApplicationDbContext> ( )
                .AddDefaultTokenProviders ( );

            // Add application services.
            services.AddTransient<IEmailSender,EmailSender> ( );

            services.AddMvc ( );

            services.AddDbContext<CuckContext> ( options =>
                      options.UseSqlServer ( Configuration.GetConnectionString ( "CuckContext" ) ) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app,IHostingEnvironment env )
        {
            if ( env.IsDevelopment ( ) )
            {
                app.UseBrowserLink ( );
                app.UseDeveloperExceptionPage ( );
                app.UseDatabaseErrorPage ( );
            }
            else
            {
                app.UseExceptionHandler ( "/Home/Error" );
            }

            app.UseStaticFiles ( );

            app.UseAuthentication ( );

            app.UseMvc ( routes =>
              {
                  routes.MapRoute (
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}" );
              } );
        }
    }
}
