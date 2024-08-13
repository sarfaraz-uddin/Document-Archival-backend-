using DocumentArchival.Models.DTO;
using DocumentArchival.Models;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentArchival.Interface;

namespace DocumentArchival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepo _DistrictRepo;
        public DistrictController(IDistrictRepo DistrictRepo)
        {
            _DistrictRepo = DistrictRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                
                var districts = await _DistrictRepo.GetAll();

                // Process the districts and their related provinces here

                return Ok(districts);
            }

            catch (Exception e)
            {
                Console.WriteLine("An error occurred while processing GetAll method in DistrictRepo." + e);
                return StatusCode(500, $"An error while processing your requests,{e.Message}, {e}");
            }
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] set04districtModelCreateVm district)
        {
            try
            {
               
                await _DistrictRepo.Create(district);
                
                return Ok("District Created Successfully");            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, $"An error while processing your requests, {e.Message}");
            }
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Update([FromBody] set04districtModelCreateVm district, int id)
        {
            try
            {
                if (id != district.set04uin)
                {
                    return BadRequest();
                }
                await _DistrictRepo.Update(district);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (e.InnerException != null && e.InnerException.Message == "Invalid data")
                {
                    return StatusCode(400, e.InnerException.Message);
                }
                else
                {
                    return StatusCode(500, "Error while processing: " + e.Message);
                }
            }
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(byte id)
        {
            try
            {
                await _DistrictRepo.Delete(id);
                return StatusCode(200, "Province deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);
            }
        }
    }
}
