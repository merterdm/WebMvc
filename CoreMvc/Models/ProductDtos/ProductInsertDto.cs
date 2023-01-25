using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CoreMvc.Models.ProductDtos
{
    public class ProductInsertDto
    {
        public int ProductId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Urun Adi zorunludur")]
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? CategoryName { get; set; }
        public IEnumerable<SelectListItem>? SupplierName { get; set; }
        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public bool? Discontinued { get; set; }

    }
}
