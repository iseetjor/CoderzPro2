using System.ComponentModel.DataAnnotations.Schema;

namespace CoderzPro2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }
        public DateTime HDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        // FK Department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
