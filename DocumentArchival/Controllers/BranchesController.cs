using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Branches")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchesRepo _branchesRepo;
        public BranchesController(IBranchesRepo branchesRepo)
        {
            _branchesRepo = branchesRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public  async Task<ActionResult<IEnumerable<bra01branches>>> GetAll()
        {
            try
            {
                return StatusCode(200, await _branchesRepo.GetAll());

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Error while processing: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody]bra01branchesModelCreateVm branchesModel)
        {
            try
            {
                await _branchesRepo.Create(branchesModel);
                return StatusCode(201, "Created Successfully");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Error while processing: " + e.Message);
            }
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult> Update(int id,[FromBody]bra01branchesModelCreateVm branchesModel)
        {
            try
            {
                if (id != branchesModel.bra01uin)
                {
                    return BadRequest();
                }
                await _branchesRepo.Update(branchesModel);
                return StatusCode(200, "Branches updated successfully");

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Invalid data")
                {
                    return StatusCode(400, ex.InnerException.Message);
                }
                else
                {
                    return StatusCode(500,  ex.Message);
                }

            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _branchesRepo.Delete(id);
                return NoContent();
            }catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Invalid data")
                {
                    return StatusCode(400, ex.InnerException.Message);
                }
                else
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

    }
}
