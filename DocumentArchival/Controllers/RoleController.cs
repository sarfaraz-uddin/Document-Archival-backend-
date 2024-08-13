using DocumentArchival.Models;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DocumentArchival.Models.DTO;

namespace DocumentArchival.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepo _roleRepo;
        public RoleController(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] rol01roleModel rol01Role)
        {
            try
            {
                await _roleRepo.AddAsync(rol01Role);
                return StatusCode(201, "Role Created Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);

            }
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _roleRepo.DeleteAsync(Id);
                return StatusCode(200, "Role deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);
            }
        }
        [HttpPut]
        [Route("Edit/{Id}")]
        public async Task<IActionResult> Edit([FromBody] rol01roleModel rol01Role, int Id)
        {
            try
            {
                await _roleRepo.UpdateAsync(Id, rol01Role);
                return StatusCode(200, "Province updated successfully");

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Invalid data")
                {
                    return StatusCode(400, ex.InnerException.Message);
                }
                else
                {
                    return StatusCode(500, "Error while processing: " + (ex.InnerException.Message != null ? ex.InnerException.Message : ex.Message));
                }

            }
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data=await _roleRepo.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);

            }
        }
    }
}
