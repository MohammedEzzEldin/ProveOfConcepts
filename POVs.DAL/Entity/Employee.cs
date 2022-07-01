using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POVs.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public double? Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        // Navigation Properity
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
