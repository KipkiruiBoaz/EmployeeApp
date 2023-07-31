using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var employee=_context.Employees.ToList();
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Post(employeeToAddDto employeeToAdd)
        {   //map dto to entity
            var employee = new Employees
            {
                Name = employeeToAdd.Name,
                Phone = employeeToAdd.Phone,
                Salary = employeeToAdd.Salary,
                Department = employeeToAdd.Department,
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();


        }
    }
}
