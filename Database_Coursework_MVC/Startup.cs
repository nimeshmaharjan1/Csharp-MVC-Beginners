using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC
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
            services.AddTransient<IStudentRepo, StudentService>();
            services.AddTransient<IFeeDepartmentRepo, FeeService>();
            services.AddTransient<ITeacherRepo, TeacherService>();
            services.AddTransient<IModuleRepo, ModuleService>();
            services.AddTransient<IAddressRepo, AddressService>();
            services.AddTransient<ITeacherModuleRepo, TeacherModuleService>();
            services.AddTransient<IStudentFeeRepo, StudentFeeService>();
            services.AddTransient<IStudentAssignmentRepo, StudentAssignmentService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Student/Index", "");
                options.Conventions.AddPageRoute("/Fee/Index", "");
                options.Conventions.AddPageRoute("/Teacher/Index", "");
                options.Conventions.AddPageRoute("/Address/Index", "");
                options.Conventions.AddPageRoute("/Module/Index", "");
                options.Conventions.AddPageRoute("/TeacherModule/Index", "");
                options.Conventions.AddPageRoute("/StudentFee/Index", "");
                options.Conventions.AddPageRoute("/StudentAssignment/Index", "");
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
