using DocumentArchival.Interface;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

namespace DocumentArchival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityRepo _MunicipalityRepo;

        public MunicipalityController(IMunicipalityRepo municipalityRepo)
        {
            _MunicipalityRepo = municipalityRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allMunicipality = await _MunicipalityRepo.GetAll();
                return Ok(allMunicipality);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while processing GetAll method in MunicipalityRepo." + e);
                return StatusCode(500, "An error while processing your requests");
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] set05municipalityModelCreateVm municipalityModel)
        {
            try
            {
                await _MunicipalityRepo.Create(municipalityModel);

                return Ok("Municipality Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "An error while processing your requests");
            }
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Update([FromBody] set05municipalityModelCreateVm municipality, int id)
        {
            try
            {
                if (id != municipality.set05uin)
                {
                    return BadRequest();
                }
                await _MunicipalityRepo.Update(municipality);
                return Ok("Muncipality Updated Successfully");
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
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _MunicipalityRepo.Delete(id);
                return StatusCode(200, "Province deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);
            }
        }
    }
}


