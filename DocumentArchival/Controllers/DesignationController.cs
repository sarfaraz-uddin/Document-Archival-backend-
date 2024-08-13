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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepo _designationRepo;

        public DesignationController(IDesignationRepo designationRepo)
        {
            _designationRepo = designationRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var designations = await _designationRepo.GetAll();
                return Ok(designations);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured in the while getting the data",ex);
                return StatusCode(500,"An error occured while geting the data");
            }     
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var designation = await _designationRepo.GetById(id);
                if (designation == null)
                {
                    return NotFound();
                }
                return Ok(designation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting designation with ID {id}", ex);
                return StatusCode(500, "An error occured while getting the data with the help of ID");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] des01designationModel designation)
        {
            try
            {
                await _designationRepo.Add(designation);
                return CreatedAtAction(nameof(GetAll), new { id = designation.des01uin }, designation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured in the while adding the data to the designaton table", ex);
                return StatusCode(500, "An error occured while adding the data");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] des01designationModel designation, int Id)
        {
            try
            {
                await _designationRepo.Update(Id,designation);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating designation with ID {designation.des01uin}", ex);
                return StatusCode(500, "An error occured while updating the  designation data");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _designationRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting designation with ID {id}", ex);
                return StatusCode(500, "An error occured while deleting the data");
            }
            
        }
    }
}
