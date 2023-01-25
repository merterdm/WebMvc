namespace CoreMvc.Models.RaporDto
{
    public class OrderReportDto
    {
        public int OrderId { get; set; }
        public string? CompanyName { get; set; }
        public string? EmployeeName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
