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
            var employee = _context.Employees.ToList();
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Post(EmployeeToAddDto employeeToAdd)
        {   //map dto to entity
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

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

        //get by id
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) { NotFound(); }
            return Ok(employee);

        }

        //update
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] long id, EmployeeToAddDto employeeToUpdate)
        { var employee = _context.Employees.Find(id);
            if (employee == null) { NotFound(); }
            employee.Name = employeeToUpdate.Name;
            employee.Phone = employeeToUpdate.Phone;
            employee.Department = employeeToUpdate.Department;
            employee.Salary = employeeToUpdate.Salary;

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id}")]   
        public IActionResult Delete(long id) 
        { var employeeToDelete= _context.Employees.Find(id);
            if (employeeToDelete == null) { NotFound();}
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
            return Ok();    
        }

    }
  }   


    

