using ComplaintService.Client.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ComplaintService
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IComplainHttpClient, ComplainHttpClient>();

            services.AddSingleton<ITokenService, TokenService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
           .AddOpenIdConnect("oidc", opt =>
            {
                opt.SignInScheme = "Cookies";
                opt.Authority = "https://localhost:5005";
                opt.ClientId = "mvc-client";
                opt.ResponseType = "code id_token";
                opt.SaveTokens = true;
                opt.ClientSecret = "MVCSecret";
                opt.GetClaimsFromUserInfoEndpoint = true;

                opt.ClaimActions.DeleteClaim("sid");
                opt.ClaimActions.DeleteClaim("idp");
                opt.Scope.Add("address");
                //opt.ClaimActions.MapUniqueJsonKey("address", "address");
                opt.Scope.Add("roles");
                opt.ClaimActions.MapUniqueJsonKey("role", "role");
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = "role"
                };
                opt.Scope.Add("complainApi.read");
                opt.Scope.Add("position");
                opt.Scope.Add("country");
                opt.ClaimActions.MapUniqueJsonKey("position", "position");
                opt.ClaimActions.MapUniqueJsonKey("country", "country");
            });
            services.AddAuthorization(authOpt =>
            {
                authOpt.AddPolicy("CanCreateAndModifyData", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.RequireClaim("position", "Administrator");
                    policyBuilder.RequireClaim("country", "Nigeria");
                });
            });
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
