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
    public class Functional_titleController : ControllerBase
    {
        private readonly IFunctional_titleRepo _functional_titleRepo;

        public Functional_titleController(IFunctional_titleRepo functional_titleRepo)
        {
            _functional_titleRepo = functional_titleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var functionalTitles = await _functional_titleRepo.GetAll();
                return Ok(functionalTitles);
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
                var functionalTitle = await _functional_titleRepo.GetById(id);
                if (functionalTitle == null)
                {
                    return NotFound();
                }
                return Ok(functionalTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting functional title with ID {id}", ex);
                return StatusCode(500, "An error occured while geting the data by ID");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]des02functional_titleModel functionalTitle)
        {
            try
            {
                await _functional_titleRepo.Add(functionalTitle);
                return CreatedAtAction(nameof(GetById), new { id = functionalTitle.des02uin }, functionalTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while adding the data", ex);
                return StatusCode(500, "An error occured while adding the data");
            }
            
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] des02functional_titleModel functionalTitle,int Id)
        {
            try
            {
                await _functional_titleRepo.Update(Id,functionalTitle);
                return Ok("Updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating functional title with ID {functionalTitle.des02uin}", ex);
                return StatusCode(500, "An error occured while updating the data");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _functional_titleRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting functional title with ID {id}", ex);
                return StatusCode(500, "An error occured while deleting the data");
            }
            
        }
    }
}
