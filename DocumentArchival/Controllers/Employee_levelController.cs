using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentArchival.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_levelController : ControllerBase
    {
        private readonly IEmployee_levelRepo _employee_levelRepo;

        public Employee_levelController(IEmployee_levelRepo employee_levelRepo)
        {
            _employee_levelRepo = employee_levelRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var employeeLevels = await _employee_levelRepo.GetAll();
                return Ok(employeeLevels);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while getting the data", ex);
                return StatusCode(500, "An error occured while geting the data");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var employeeLevel = await _employee_levelRepo.GetById(id);
                if (employeeLevel == null)
                {
                    return NotFound();
                }
                return Ok(employeeLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting Employee level with ID {id}", ex);
                return StatusCode(500, "An error occured while geting data with Id");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] lvl01employee_levelModel employeeLevel)
        {
            try
            {
                await _employee_levelRepo.Add(employeeLevel);
                return CreatedAtAction(nameof(GetById), new { id = employeeLevel.lvl01uin }, employeeLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured in the while adding the data", ex);
                return StatusCode(500, "An error occured while adding the data");
            }
            
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] lvl01employee_levelModel employeeLevel,int Id )
        {
            try
            {
                await _employee_levelRepo.Update(Id,employeeLevel);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating employee levels with ID {employeeLevel.lvl01uin}", ex);
                return StatusCode(500, "An error occured while updating the data");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employee_levelRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting employee levels with ID {id}", ex);
                return StatusCode(500, "An error occured while deleting the data");
            }
            
        }
    }
}
