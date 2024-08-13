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
    [Route("Province")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepo _provinceRepo;
        public ProvinceController(IProvinceRepo provinceRepo)
        {
            _provinceRepo = provinceRepo;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm] set03provinceModel set03ProvinceModel)
        {
            try
            {
                var insertValue = new set03province();
                insertValue.set03code = set03ProvinceModel.set03code;
                insertValue.set03title = set03ProvinceModel.set03title;
                insertValue.set03remarks = set03ProvinceModel.set03remarks;
                insertValue.set03status = set03ProvinceModel.set03status;
                insertValue.set03deleted = false;
                insertValue.set03created_at = DateTime.Now;
                insertValue.set03created_by = "Ram";
                await _provinceRepo.AddAsync(insertValue);
                return StatusCode(201, "Province created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);

            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(byte id)
        {
            try
            {
                await _provinceRepo.DeleteAsync(id);
                return StatusCode(200, "Province deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);
            }
        }
        [HttpPut]
        [Route("Edit/{Id}")]
        public async Task<IActionResult> Edit([FromForm] set03provinceModel set03ProvinceModel, byte Id)
        {
            try
            {
                await _provinceRepo.UpdateAsync(Id, set03ProvinceModel);
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
                return StatusCode(200, await _provinceRepo.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);

            }
        }

    }
}
