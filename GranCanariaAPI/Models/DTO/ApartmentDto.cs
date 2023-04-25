using System.ComponentModel.DataAnnotations;

namespace GranCanariaAPI.Models.DTO
{
    public class ApartmentDto
    {
        public int ApartmentId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Kvm { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Comfort { get; set; }
    }
}
