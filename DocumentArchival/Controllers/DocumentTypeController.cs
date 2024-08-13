using DocumentArchival.Interface;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentArchival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepo _documentTypeRepo;
        public DocumentTypeController(IDocumentTypeRepo documentTypeRepo)
        {
            _documentTypeRepo = documentTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentType = await _documentTypeRepo.GetAllAsync();
            return Ok(documentType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var documentType = await _documentTypeRepo.GetByIdAsync(id)
    ;
            if (documentType == null)
            {
                return NotFound();
            }
            return Ok(documentType);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] fil09document_typeModel fil09document_typeModel)
        {
            var documentType = new fil09document_type
            {
                fil09title = fil09document_typeModel.fil09title,
                fil09created_at = DateTime.Now,
                fil09created_by = fil09document_typeModel.fil09created_by,
                fil09updated_at = fil09document_typeModel.fil09updated_at,
                fil09updated_by = fil09document_typeModel.fil09updated_by
            };
            await _documentTypeRepo.AddAsync(documentType);
            return CreatedAtAction(nameof(GetById), new { id = documentType.fil09uin }, documentType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm] fil09document_typeUpdateModel fil09Document_Type)
        {
            if (id != fil09Document_Type.fil09uin)
            {
                return BadRequest();
            }
            var documentType = new fil09document_type
            {
                fil09uin= fil09Document_Type.fil09uin,
                fil09title = fil09Document_Type.fil09title,
                fil09created_at = fil09Document_Type.fil09created_at,
                fil09created_by = fil09Document_Type.fil09created_by,
                fil09updated_at = fil09Document_Type.fil09updated_at,
                fil09updated_by = fil09Document_Type.fil09updated_by
            };
            await _documentTypeRepo.UpdateAsync(documentType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentTypeRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
