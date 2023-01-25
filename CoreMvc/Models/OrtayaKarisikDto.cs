using CoreMvc.Entities;

namespace CoreMvc.Models
{
    public class OrtayaKarisikDto
    {

        public OrtayaKarisikDto()
        {
            Categories = new List<Category>();
            Regions = new List<Region>();
            Shippers = new List<Shipper>();
        }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Shipper> Shippers { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
