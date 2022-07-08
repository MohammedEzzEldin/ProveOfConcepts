using POVs.DAL.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace POVs.BL.ModelView
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            //IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Name!!!")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Email { get; set; }
        [
            RegularExpression(
            "[1-9]{1,5}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}",
            ErrorMessage ="Enter like 12-streetname-City-Country"
           )
        ]
        public string Address { get; set; }
        public string Notes { get; set; }
        [Range(2000,10000,ErrorMessage ="Salary btw 2k to 100k")]
        public double? Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
