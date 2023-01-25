using CoreEmptyMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreEmptyMvc.Controllers
{
    public class KisiController : Controller
    {
        public IActionResult Index()
        {
            List<Kisi> kisiler = new List<Kisi>
            {
                new Kisi { Id = 1,Ad="Ali",Soyad="Yilmaz"},
                new Kisi { Id = 2,Ad="Veli",Soyad="Taş"},
                new Kisi { Id = 3,Ad="Ayse",Soyad="Kaya"},
                new Kisi { Id = 4,Ad="Fatma",Soyad="Guner"},
                new Kisi { Id = 5,Ad="Hasan",Soyad="OndeGider"}


            };

            return View(kisiler);
        }
    }
}
