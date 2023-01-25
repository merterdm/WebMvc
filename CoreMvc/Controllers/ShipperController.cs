using CoreMvc.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NorthwindContext context;

        public ShipperController(NorthwindContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            var result = context.Shippers.ToList();
            return View(result);
        }

        public IActionResult GetOrders(int id)
        {
            var result = context.Shippers.Include(p => p.Orders).Where(p => p.ShipperId == id).FirstOrDefault();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var shipper = new CoreMvc.Entities.Shipper();
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Create(CoreMvc.Entities.Shipper shipper)
        {
            if (!ModelState.IsValid)
            {
                return View(shipper);
            }

            context.Shippers.Add(shipper);

            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }
            return View(shipper);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var shipper = context.Shippers.Find(id);
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Update(CoreMvc.Entities.Shipper? shipper)
        {

            if (!ModelState.IsValid)
            {
                return View(shipper);

            }
            context.Shippers.Update(shipper);
            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Shipper");
            }
            return View(shipper);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var shipper = context.Shippers.Find(id);
            return View(shipper);
        }
        [HttpPost]
        public IActionResult Delete(CoreMvc.Entities.Shipper? shipper)
        {


            context.Shippers.Remove(shipper);
            int sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Shipper");
            }
            return View(shipper);
        }

        public IActionResult GetOrderDetails(int id)
        {
            var result = context.OrderDetails
                        .Include(p => p.Product)
                        .ThenInclude(p => p.Category)
                        .Where(p => p.OrderId == id)
                        .ToList();


            return View(result);
        }




    }
}
