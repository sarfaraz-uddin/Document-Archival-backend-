using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using DocumentArchival.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DocumentArchival.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveDocumentController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IBranchesRepo _branchesRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly ApplicationDbContext _db;

        public ArchiveDocumentController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext db, IDepartmentRepo departmentRepo, IBranchesRepo branchesRepo, IRoleRepo roleRepo)
        {
            _webHostEnvironment = webHostEnvironment;
            _departmentRepo = departmentRepo;
            _branchesRepo = branchesRepo;
            _roleRepo = roleRepo;
            _db = db;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

        }
        [HttpGet]
        [Route("archive-documents")]
        public async Task<ActionResult> ArchiveDocument()
        {
            try
            {
                var departmentList = await _departmentRepo.GetDepartmentsIdAndName();
                var branchList = await _branchesRepo.GetBranchesIdAndName();
                var roleList = await _roleRepo.GetRolesIdAndName();
                var dropDownData = new
                {
                    Departments = departmentList,
                    Branches = branchList,
                    Roles = roleList
                };
                return Ok(dropDownData);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error while processing your requests");
            }
        }

        [HttpPost]
        [Route("archive-documents")]
        public IActionResult ArchiveDocument([FromBody] DocumentSummaryViewModel viewModel)
        {
            var documentSummary = new fil01document_summary
            {
                fil01bra01uin = viewModel.Fil01Bra01Uin,
                fil01dep01uin = viewModel.Fil01Dep01Uin,
                fil01owner = viewModel.Fil01Owner,
                fil01created_at = DateTime.Now,
                file01created_by = "Ram"
            };
            foreach (var detailViewModel in viewModel.DocumentDetails)
            {
                var documentDetail = new fil02document_detail
                {
                    fil02doctitle = detailViewModel.Fil02DocTitle,
                    fil02fil09uin = detailViewModel.Fil02DocType,
                    fil02fil10uin = detailViewModel.Fil02DocCategory,
                    fil02description = detailViewModel.Fil02Description,
                    fil02expirydate = detailViewModel.Fil02ExpiryDate,
                    fil02isconfidential = detailViewModel.Fil02IsConfidential,
                    fil02version = detailViewModel.Fil02Version,
                    fil02docphysicallocation = detailViewModel.Fil02DocPhysicalLocation,
                    fil02created_at = DateTime.Now,
                    file02created_by = "Ram",
                    fil01document_summary = documentSummary
                };

                foreach (var tagViewModel in detailViewModel.Tags)
                {
                    var tag = new fil04tag
                    {
                        fil04title = tagViewModel.Fil04Title,
                        fil04created_at = DateTime.Now,
                        fil04created_by = "Ram",
                        fil02document_detail = documentDetail
                    };

                    _db.fil04tags.Add(tag);
                }

                foreach (var attachViewModel in detailViewModel.AttachDocuments)
                {
                    var attachDocument = new fil03attach_document
                    {
                        fil03name = attachViewModel.Fil03Name,
                        fil03size = attachViewModel.Fil03Size,
                        file03path = attachViewModel.Fil03Path,
                        fil03created_at = DateTime.Now,
                        fil03created_by = "Ram",
                        fil02document_detail = documentDetail
                    };

                    foreach (var branchPermissionViewModel in attachViewModel.BranchPermissions)
                    {
                        var branchPermission = new fil05branch_permission
                        {
                            fil05bra01uin = branchPermissionViewModel.Fil05Bra01Uin,
                            fil05permission_type = branchPermissionViewModel.Fil05PermissionType,
                            fil05created_at = DateTime.Now,
                            fil05created_by = "Ram",
                            fil03attach_document = attachDocument

                        };

                        _db.fil05branch_permissions.Add(branchPermission);
                    }

                    foreach (var departmentPermissionViewModel in attachViewModel.DepartmentPermissions)
                    {
                        var departmentPermission = new fil06department_permission
                        {
                            fil06dep01uin = departmentPermissionViewModel.Fil06Dep01Uin,
                            fil06permission_type = departmentPermissionViewModel.Fil06PermissionType,
                            fil06created_at = DateTime.Now,
                            fil06created_by = "Ram",
                            fil03attach_document = attachDocument
                        };

                        _db.fil06department_permissions.Add(departmentPermission);
                    }

                    foreach (var rolePermissionViewModel in attachViewModel.RolePermissions)
                    {
                        var rolePermission = new fil07role_permission
                        {
                            fil07rol01uin = rolePermissionViewModel.Fil07Rol01Uin,
                            fil07permission_type = rolePermissionViewModel.Fil07PermissionType,
                            fil07created_at = DateTime.Now,
                            fil07created_by = "Ram",
                            fil03attach_document = attachDocument
                        };

                        _db.fil07role_permissions.Add(rolePermission);
                    }

                    foreach (var userPermissionViewModel in attachViewModel.UserPermissions)
                    {
                        var userPermission = new fil08user_permission
                        {
                            fil08emp01uin = userPermissionViewModel.Fil08Emp01Uin,
                            fil08permission_type = userPermissionViewModel.Fil08PermissionType,
                            fil08created_at = DateTime.Now,
                            fil08created_by = "Ram",
                            fil03attach_document = attachDocument
                        };

                        _db.fil08User_Permissions.Add(userPermission);
                    }

                    _db.fil03attach_documents.Add(attachDocument);
                }

                _db.fil02Document_Details.Add(documentDetail);
            }
            _db.fil01document_summaries.Add(documentSummary);
            _db.SaveChanges();
            var createdDocument = _db.fil01document_summaries
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
       .FirstOrDefault(ds => ds.fil01uin == documentSummary.fil01uin);
            var jsonData = JsonSerializer.Serialize(createdDocument, _jsonOptions);
            return Ok(jsonData);
        }

        [HttpGet]
        [Route("filter-documents")]
        public IActionResult FilterDocuments(int? doctype, string doctitle, string? version, bool? isconfidential)
        {
            try
            {
                var query = _db.fil01document_summaries
                .Include(ds => ds.fil02document_details)
                    .ThenInclude(dd => dd.fil04Tags)
                .Include(ds => ds.fil02document_details)
                    .ThenInclude(dd => dd.fil03attach_documents)
                        .ThenInclude(ad => ad.fil05branch_permissions)
                .Include(ds => ds.fil02document_details)
                    .ThenInclude(dd => dd.fil03attach_documents)
                        .ThenInclude(ad => ad.fil06department_permissions)
                .Include(ds => ds.fil02document_details)
                    .ThenInclude(dd => dd.fil03attach_documents)
                        .ThenInclude(ad => ad.fil07role_permissions)
                .Include(ds => ds.fil02document_details)
                    .ThenInclude(dd => dd.fil03attach_documents)
                        .ThenInclude(ad => ad.fil08user_permissions)
                .AsQueryable();

                if (doctype.HasValue)
                {
                    query = query.Where(ds => ds.fil02document_details.Any(dd => dd.fil02fil09uin == doctype.Value));
                }

                if (!string.IsNullOrEmpty(doctitle))
                {
                    query = query.Where(ds => ds.fil02document_details.Any(dd => dd.fil02doctitle.Contains(doctitle)));
                }

                if (!string.IsNullOrEmpty(version))
                {
                    query = query.Where(ds => ds.fil02document_details.Any(dd => dd.fil02version.Contains(version)));
                }

                if (isconfidential.HasValue)
                {
                    query = query.Where(ds => ds.fil02document_details.Any(dd => dd.fil02isconfidential == isconfidential.Value));
                }

                var filteredDocuments = query
                    .Select(ds => new DocumentSummaryViewModel
                    {
                        Fil01Bra01Uin = ds.fil01bra01uin,
                        Fil01Dep01Uin = ds.fil01dep01uin,
                        Fil01Owner = ds.fil01owner,
                        DocumentDetails = ds.fil02document_details
                            .Where(dd =>
                                (!doctype.HasValue || dd.fil02fil09uin == doctype.Value) &&
                                (string.IsNullOrEmpty(doctitle) || dd.fil02doctitle.Contains(doctitle)) &&
                                (string.IsNullOrEmpty(version) || dd.fil02version.Contains(version)) &&
                                (!isconfidential.HasValue || dd.fil02isconfidential == isconfidential.Value))
                            .Select(dd => new DocumentDetailViewModel
                            {
                                Fil02DocTitle = dd.fil02doctitle,
                                Fil02DocType = dd.fil02fil09uin,
                                Fil02DocCategory = dd.fil02fil10uin,
                                Fil02ExpiryDate = dd.fil02expirydate,
                                Fil02IsConfidential = dd.fil02isconfidential,
                                Fil02Version = dd.fil02version,
                                Fil02Description = dd.fil02description,
                                Fil02DocPhysicalLocation = dd.fil02docphysicallocation,
                                Tags = dd.fil04Tags.Select(t => new TagViewModel
                                {
                                    Fil04Title = t.fil04title
                                }).ToList(),
                                AttachDocuments = dd.fil03attach_documents.Select(ad => new AttachDocumentViewModel
                                {
                                    Fil03Name = ad.fil03name,
                                    Fil03Size = ad.fil03size,
                                    Fil03Path = ad.file03path,
                                    BranchPermissions = ad.fil05branch_permissions.Select(bp => new BranchPermissionViewModel
                                    {
                                        Fil05Bra01Uin = bp.fil05bra01uin,
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
                var jsonData = JsonSerializer.Serialize(filteredDocuments, _jsonOptions);
                return Ok(jsonData);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error while processing your requests");

            }
        }
    }
}
