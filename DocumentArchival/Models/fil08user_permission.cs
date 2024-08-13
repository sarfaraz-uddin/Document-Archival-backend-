using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil08user_permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil08uin { get; set; }
        [ForeignKey("emp01employee")]
        public int fil08emp01uin { get; set; }
        [ForeignKey("fil03attach_document")]
        public int fil08fil03uin { get; set; }
        public EnumPermissionType fil08permission_type { get; set; }
        public DateTime fil08created_at { get; set; }
        public string fil08created_by { get; set; }
        public DateTime? fil08updated_at { get; set; }
        public string? fil08updated_by { get; set; }
        public virtual emp01employee emp01employee { get; set; }
        public virtual fil03attach_document fil03attach_document { get; set; }

    }
}
