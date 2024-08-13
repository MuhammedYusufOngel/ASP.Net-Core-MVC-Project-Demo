using BlogApiDemo.Controllers.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //GetAll
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        //Adding
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        //getById
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        //deleteByid
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        //updateByid
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee p)
        {
            using var c = new Context();
            var employee = c.Find<Employee>(p.ID);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                employee.Name = p.Name;
                c.Update(employee);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
