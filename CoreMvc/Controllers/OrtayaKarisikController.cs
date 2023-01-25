using CoreMvc.Entities;
using CoreMvc.Models;
using CoreMvc.Models.RaporDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Controllers
{
    public class OrtayaKarisikController : Controller
    {
        private readonly NorthwindContext context;

        public OrtayaKarisikController(NorthwindContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            OrtayaKarisikDto karisikDto = new OrtayaKarisikDto();
            karisikDto.Categories = context.Categories.ToList();
            karisikDto.Regions = context.Regions.ToList();
            karisikDto.Shippers = context.Shippers.ToList();
            return View(karisikDto);
        }
        public IActionResult Rapor()
        {

            //@*Order Id , Customer Name, Employee Name ,Country ,City , Order Date*@

            var result = context.Orders
                .Include(p => p.Customer)
                .Include(p => p.Employee)
                .Select(p => new OrderReportDto
                {
                    OrderId = p.OrderId,
                    CompanyName = p.Customer.CompanyName,
                    EmployeeName = (p.Employee.FirstName + " " + p.Employee.LastName),
                    Country = p.ShipCountry,
                    City = p.ShipCity,
                    OrderDate = p.OrderDate,
                    ShippedDate = p.ShippedDate
                }).ToList();





            return View(result);
        }
    }
}
