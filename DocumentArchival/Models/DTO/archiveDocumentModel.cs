using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models.DTO
{
    public class DocumentSummaryViewModel
    {
        public int Fil01Bra01Uin { get; set; }
        public int Fil01Dep01Uin { get; set; }
        public string Fil01Owner { get; set; }
        public List<DocumentDetailViewModel> DocumentDetails { get; set; } = new List<DocumentDetailViewModel>();
    }

    public class DocumentDetailViewModel
    {
        public string Fil02DocTitle { get; set; }
        public int Fil02DocType { get; set; }
        public int Fil02DocCategory { get; set; }
        public DateTime Fil02ExpiryDate { get; set; }
        public bool Fil02IsConfidential { get; set; }
        public string Fil02Version { get; set; }
        public string Fil02Description { get; set; }
        public string Fil02DocPhysicalLocation { get; set; }
        public List<AttachDocumentViewModel> AttachDocuments { get; set; } = new List<AttachDocumentViewModel>();
        public List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
    }

    public class AttachDocumentViewModel
    {
        public string Fil03Name { get; set; }
        public string Fil03Size { get; set; }
        public string Fil03Path { get; set; }
        public List<BranchPermissionViewModel> BranchPermissions { get; set; } = new List<BranchPermissionViewModel>();
        public List<DepartmentPermissionViewModel> DepartmentPermissions { get; set; } = new List<DepartmentPermissionViewModel>();
        public List<RolePermissionViewModel> RolePermissions { get; set; } = new List<RolePermissionViewModel>();
        public List<UserPermissionViewModel> UserPermissions { get; set; } = new List<UserPermissionViewModel>();
    }

    public class TagViewModel
    {
        public string Fil04Title { get; set; }
    }

    public class BranchPermissionViewModel
    {
        public int Fil05Bra01Uin { get; set; }
        public EnumPermissionType Fil05PermissionType { get; set; }
    }

    public class DepartmentPermissionViewModel
    {
        public int Fil06Dep01Uin { get; set; }
        public EnumPermissionType Fil06PermissionType { get; set; }

    }

    public class RolePermissionViewModel
    {
        public int Fil07Rol01Uin { get; set; }
        public EnumPermissionType Fil07PermissionType { get; set; }

    }

    public class UserPermissionViewModel
    {
        public int Fil08Emp01Uin { get; set; }
        public EnumPermissionType Fil08PermissionType { get; set; }

    }

}
