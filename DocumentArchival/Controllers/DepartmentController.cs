using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentArchival.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _DepartmentRepo;
        public DepartmentController(IDepartmentRepo DepartmentRepo)
        {
            _DepartmentRepo = DepartmentRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<dep01department>>> GetAll()
        {
            try
            {
                IEnumerable<dep01department> allDepartment = await _DepartmentRepo.GetAll();
                return Ok(allDepartment);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error while processing your requests");
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] dep01departmentModel department)
        {
            try
            {
                var insertValue = new dep01department();
                insertValue.dep01created_at = DateTime.Now;
                insertValue.dep01created_by = "initialUser";
                insertValue.dep01title = department.dep01title;
                insertValue.dep01code = department.dep01code;
                insertValue.dep01status = true;
                insertValue.dep01deleted = false;
                await _DepartmentRepo.Create(insertValue);
                return StatusCode(201, "Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "An error while processing your requests");
            }
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Update([FromBody] dep01departmentModel department, int id)
        {
            try
            {
                if (id != department.dep01uin)
                {
                    return BadRequest();
                }
                await _DepartmentRepo.Update(department);
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
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _DepartmentRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
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