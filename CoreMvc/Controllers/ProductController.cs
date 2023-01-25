using AutoMapper;
using CoreMvc.Entities;
using CoreMvc.Models.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext context;
        private readonly IMapper mapper;

        public ProductController(NorthwindContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        public IActionResult Index()
        {
            ICollection<ProductIndexDto> indexDtos = new HashSet<ProductIndexDto>();

            var products = this.context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Supplier)
                            .ToList();
            //var result = mapper.Map<ProductIndexDto>(products);


            // Amele Yontemi
            foreach (var product in products)
            {
                ProductIndexDto productIndexDto = new ProductIndexDto
                {
                    ProductId = product.ProductId,
                    CategoryName = product.Category.CategoryName,
                    SupplierName = product.Supplier.CompanyName,
                    Discontinued = product.Discontinued,
                    ProductName = product.ProductName,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    UnitsOnOrder = product.UnitsOnOrder
                };

                indexDtos.Add(productIndexDto);

            }


            return View(indexDtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var category = context.Categories.ToList();
            var supplier = context.Suppliers.ToList();


            var product = new ProductInsertDto()
            {
                CategoryName = context.Categories.Select(p => new SelectListItem
                {
                    Text = p.CategoryName,
                    Value = p.CategoryId.ToString()
                }).ToList(),
                SupplierName = context.Suppliers.Select(p => new SelectListItem
                {
                    Text = p.CompanyName,
                    Value = p.SupplierId.ToString()
                }).ToList()
            };

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductInsertDto dto)
        {


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage).FirstOrDefault());
                dto = SetupProducDto(dto);
                return View(dto);
            }

            if (dto.CategoryId == 0)
            {
                dto = SetupProducDto(dto);
                ModelState.AddModelError("", "Lutfen Bir Kategory Seciniz");
                return View(dto);
            }

            if (dto.SupplierId == 0)
            {
                dto = SetupProducDto(dto);
                ModelState.AddModelError("", "Lutfen Bir Tedarikci  Seciniz");
                return View(dto);
            }

            dto = SetupProducDto(dto);


            return View(dto);
        }

        [NonAction]
        public ProductInsertDto SetupProducDto(ProductInsertDto dto)
        {
            dto.CategoryName = context.Categories.Select(p => new SelectListItem
            {
                Text = p.CategoryName,
                Value = p.CategoryId.ToString()
            }).ToList();

            dto.SupplierName = context.Suppliers.Select(p => new SelectListItem
            {
                Text = p.CompanyName,
                Value = p.SupplierId.ToString()
            }).ToList();
            return dto;


        }



        [HttpPost]
        public JsonResult GetProducts()
        {
            int totalRecord = 0;
            int filterRecord = 0;
            var draw = Request.Form["draw"].FirstOrDefault();
            string shortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

            var data = context.Set<Product>().AsQueryable();
            totalRecord = data.Count();

            // search data
            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x => x.ProductName.Contains(searchValue));
            }
            filterRecord = data.Count();
            var productList = data.Skip(skip).Take(pageSize).ToList();
            var returnObj = new
            {
                draw = draw,
                recordsTotal = totalRecord,
                recordFiltered = filterRecord,
                data = productList
            };
            return Json(returnObj);
        }



    }
}
