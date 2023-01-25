using AutoMapper;
using CoreMvc.Entities;
using CoreMvc.Models.EmployeeDTO;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NorthwindContext context;
        private readonly IMapper mapper;

        public EmployeeController(NorthwindContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {

            var result = context.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EmployeeInsertDTO insertDTO = new EmployeeInsertDTO();
            return View(insertDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeInsertDTO dTO)
        {

            if (!ModelState.IsValid)
            {

                return View(dTO);
            }

            if (dTO.BirtDate.Value.Year < 2020)
            {
                ModelState.AddModelError("", "Dogum Tarihi 2020'den kucuk olamaz");
                return View(dTO);
            }

            // Amele Yontemi 

            //Employee newEmp = new Employee
            //{
            //    FirstName = dTO.FirstName,
            //    LastName = dTO.LastName,
            //    Title = dTO.Title,
            //    BirthDate = dTO.BirtDate
            //};

            var employee = mapper.Map<Employee>(dTO);


            context.Employees.Add(employee);
            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }
            return View(dTO);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var employee = context.Employees.Find(id);
            var dto = mapper.Map<EmployeeUpdateDto>(employee);


            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var employee = mapper.Map<Employee>(dto);
            context.Employees.Update(employee);
            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }


            return View(dto);
        }
    }
}
