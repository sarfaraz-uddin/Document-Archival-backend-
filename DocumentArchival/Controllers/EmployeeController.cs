using DocumentArchival.Interface;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentArchival.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var employees = await _employeeRepo.GetAll();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting the data", ex);
                return StatusCode(500, "An error occurred while getting the data");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] emp01employeeModel employee)
        {
            try
            {
                await _employeeRepo.Create(employee);
                return CreatedAtAction(nameof(GetAll), new { id = employee.emp01uin }, employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding the data to the employee table", ex);
                return StatusCode(500, "An error occurred while adding the data");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] emp01employeeModel employee, int id)
        {
            try
            {
                await _employeeRepo.Update(id, employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating employee with ID {employee.emp01uin}", ex);
                return StatusCode(500, "An error occurred while updating the employee data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting employee with ID {id}", ex);
                return StatusCode(500, "An error occurred while deleting the data");
            }
        }
    }
}
