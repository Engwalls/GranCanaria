using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranCanariaAPI.Models
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Kvm { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Comfort { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
