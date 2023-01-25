using CoreMvc.AutoMapper;
using CoreMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {





            var builder = WebApplication.CreateBuilder(args);
            //string qwe = "Alli veli 4950";
            //var kelimeler = qwe.WordCount();

            // Add services to the container.


            //AutoMapper 'i IOC Container'a regisster Ettik
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddControllersWithViews();

            //Database Contex'i IOC Container'are register ettik
            builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("northwind")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.Run(() => { Console.WriteLine("Islem Bitti"); });

            //app.Use(async (context, task) =>
            //{
            //    System.Console.WriteLine(" Start use MiddleWare 1");
            //    task.Invoke();
            //    System.Console.WriteLine("Stop Use MiddleWare 1");
            //});

            //app.Use(async (context, task) =>
            //{
            //    System.Console.WriteLine(" Start use MiddleWare 2");
            //    task.Invoke();
            //    System.Console.WriteLine("Stop Use MiddleWare 2");
            //});


            //app.Use(async (context, task) =>
            //{
            //    System.Console.WriteLine(" Start use MiddleWare 3");
            //    task.Invoke();
            //    System.Console.WriteLine("Stop Use MiddleWare 3");
            //});


            //app.Map("/", builder =>
            //{
            //    builder.Run(async c => await c.Response.WriteAsync("Middleware Map Casliti"));
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}