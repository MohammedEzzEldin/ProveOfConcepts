
using System.ComponentModel.DataAnnotations;

namespace POVs.BL.ModelView
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Provide Name!!!")]
        [MaxLength(50,ErrorMessage ="Max length is 50")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Provide Code!!!")]
        [MaxLength(50,ErrorMessage ="Max length is 20")]
        [Range(1,100,ErrorMessage ="Range btw 1 and 100")]
        public string Code { get; set; }
    }
}
