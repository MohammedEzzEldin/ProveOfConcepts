using POVs.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace POVs.BL.ModelView
{
    public class DistrictVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Name!!!")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
