using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class EmployeeToAddDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string Department { get; set; }
    }
}

