namespace CoreEmptyMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            //app.MapGet("/", () => "Hello World!");
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            #region Routing
            //Route (Yonlendirme)
            //Gelen istekleri Url'leriyle eþlestiren ve isleyen rota olarak tanimlanabilir
            // Dotnet.Core'da varsayilan yonlendirme endpoint routing olarak isimlendirilir.
            // Kullanici itekte bulundugu zaman hangi controller icin calisacagini ,
            // Hangi actio'i iligili modeli ile geri donecegini burada UseRouting middleware yapisi ile
            // gerceklestiririz.
            // Bu middleware sayesinde gelen istege karsi 
            //hangi controller calisacagini ve comntroller
            //icerisindeki hangi action'nin teiklenecegini  belirleyebiliriz. 
            //Bunun icin kullanilna middleware ise  UseEndPoint middleware'dir

            #endregion
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Kisi}/{action=Index}/{id?}"
                    );
            });
            app.Run();
        }
    }
}