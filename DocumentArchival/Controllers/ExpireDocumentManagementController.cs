using DocumentArchival.Data;
using DocumentArchival.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocumentArchival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpireDocumentManagementController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly JsonSerializerOptions _jsonOptions;
        public ExpireDocumentManagementController(ApplicationDbContext db)
        {
            _db = db;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

        }
        [HttpGet]
        [Route("Get/{expireWithIn}")]
        public IActionResult Get(int? expireWithIn)
        {
            try
            {
                int expireWithinDays = expireWithIn ?? 15;
                DateTime now = DateTime.Now;
                DateTime expireDate = now.AddDays(expireWithinDays);

                // Fetch the data from the database
                var list = _db.fil01document_summaries
                    .Include(ds => ds.fil02document_details)
                        .ThenInclude(dd => dd.fil04Tags)
                    .Include(ds => ds.fil02document_details)
                        .ThenInclude(dd => dd.fil03attach_documents)
                            .ThenInclude(ad => ad.fil05branch_permissions)
                                .ThenInclude(bp => bp.bra01branches)
                    .Include(ds => ds.fil02document_details)
                        .ThenInclude(dd => dd.fil03attach_documents)
                            .ThenInclude(ad => ad.fil06department_permissions)
                                .ThenInclude(dp => dp.dep01department)
                    .Include(ds => ds.fil02document_details)
                        .ThenInclude(dd => dd.fil03attach_documents)
                            .ThenInclude(ad => ad.fil07role_permissions)
                                .ThenInclude(rp => rp.rol01role)
                    .Include(ds => ds.fil02document_details)
                        .ThenInclude(dd => dd.fil03attach_documents)
                            .ThenInclude(ad => ad.fil08user_permissions)
                                .ThenInclude(up => up.emp01employee)
                    .AsEnumerable() // Fetch data to memory
                    .Where(ds => ds.fil02document_details.Any(x => x.fil02expirydate <= expireDate)) // Apply filter in memory
                    .Select(ds => new DocumentSummaryViewModel
                    {
                        Fil01Owner = ds.fil01owner,
                        Fil01Bra01Uin = ds.fil01bra01uin,
                        Fil01Dep01Uin = ds.fil01dep01uin,
                        DocumentDetails = ds.fil02document_details
                            .Where(dd => dd.fil02expirydate <= expireDate)
                            .Select(dd => new DocumentDetailViewModel
                            {
                                Fil02Description = dd.fil02description,
                                Fil02DocCategory = dd.fil02fil10uin,
                                Fil02DocPhysicalLocation = dd.fil02docphysicallocation,
                                Fil02DocTitle = dd.fil02doctitle,
                                Fil02DocType = dd.fil02fil09uin,
                                Fil02ExpiryDate = dd.fil02expirydate,
                                Fil02IsConfidential = dd.fil02isconfidential,
                                Fil02Version = dd.fil02version,
                                Tags = dd.fil04Tags.Select(t => new TagViewModel
                                {
                                    Fil04Title = t.fil04title,
                                }).ToList(),
                                AttachDocuments = dd.fil03attach_documents.Select(ad => new AttachDocumentViewModel
                                {
                                    Fil03Name = ad.fil03name,
                                    Fil03Size = ad.fil03size,
                                    Fil03Path = ad.file03path,
                                    BranchPermissions = ad.fil05branch_permissions.Select(bp => new BranchPermissionViewModel
                                    {
                                        Fil05Bra01Uin = bp.fil05bra01uin,
                                        /*    BranchName = bp.bra01branches.bra01branchname,*/
                                        Fil05PermissionType = bp.fil05permission_type
                                    }).ToList(),
                                    DepartmentPermissions = ad.fil06department_permissions.Select(dp => new DepartmentPermissionViewModel
                                    {
                                        Fil06Dep01Uin = dp.fil06dep01uin,
                                        Fil06PermissionType = dp.fil06permission_type
                                    }).ToList(),
                                    RolePermissions = ad.fil07role_permissions.Select(rp => new RolePermissionViewModel
                                    {
                                        Fil07Rol01Uin = rp.fil07rol01uin,
                                        Fil07PermissionType = rp.fil07permission_type
                                    }).ToList(),
                                    UserPermissions = ad.fil08user_permissions.Select(up => new UserPermissionViewModel
                                    {
                                        Fil08Emp01Uin = up.fil08emp01uin,
                                        Fil08PermissionType = up.fil08permission_type
                                    }).ToList()
                                }).ToList()
                            }).ToList()
                    }).ToList();

                var jsonData = JsonSerializer.Serialize(list, _jsonOptions);
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while processing: " + ex.Message);
            }
        }

    }

}
