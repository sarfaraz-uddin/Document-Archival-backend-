using DocumentArchival.Interface;
using DocumentArchival.Models.DTO;
using DocumentArchival.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentArchival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentCategoryController : ControllerBase
    {
        private readonly IDocumentCategoryRepo _documentCategoryRepo;

        public DocumentCategoryController(IDocumentCategoryRepo documentCategoryRepo)
        {
            _documentCategoryRepo = documentCategoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentCategories = await _documentCategoryRepo.GetAllAsync();
            return Ok(documentCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var documentCategory = await _documentCategoryRepo.GetByIdAsync(id)
    ;
            if (documentCategory == null)
            {
                return NotFound();
            }
            return Ok(documentCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] fil10document_categoryModel fil10document_category)
        {
            var documentCategory = new fil10document_category();
            documentCategory.fil10fil09uin = fil10document_category.fil10fil09uin;
            documentCategory.fil10title = fil10document_category.fil10title;
            documentCategory.fil10created_at = DateTime.Now;
            documentCategory.fil10created_by = "ram";
            documentCategory.fil10updated_at = fil10document_category.fil10updated_at;
            documentCategory.fil10updated_by = fil10document_category.fil10updated_by;
/*            documentCategory.fil09document_type = fil10document_category.fil09document_type;
*/            await _documentCategoryRepo.AddAsync(documentCategory);
            return CreatedAtAction(nameof(GetById), new { id = documentCategory.fil10uin }, documentCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm] fil10document_categoryUpdateModel fil10document_category)
        {
            if (id != fil10document_category.fil10uin)
            {
                return BadRequest();
            }
            var documentCategory = new fil10document_category();
            documentCategory.fil10uin = fil10document_category.fil10uin;
            documentCategory.fil10fil09uin = fil10document_category.fil10fil09uin;
            documentCategory.fil10title = fil10document_category.fil10title;
            documentCategory.fil10created_at = fil10document_category.fil10created_at;
            documentCategory.fil10created_by = fil10document_category.fil10created_by;
            documentCategory.fil10updated_at = fil10document_category.fil10updated_at;
            documentCategory.fil10updated_by = fil10document_category.fil10updated_by;
            await _documentCategoryRepo.UpdateAsync(documentCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentCategoryRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
