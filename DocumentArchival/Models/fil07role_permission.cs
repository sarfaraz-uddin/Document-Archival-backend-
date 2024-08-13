using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil07role_permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil07uin { get; set; }
        [ForeignKey("rol01role")]
        public int fil07rol01uin { get; set; }
        [ForeignKey("fil03attach_document")]
        public int fil07fil03uin { get; set; }
        public EnumPermissionType fil07permission_type { get; set; }
        public DateTime fil07created_at { get; set; }
        public string fil07created_by { get; set; }
        public DateTime? fil07updated_at { get; set; }
        public string? fil07updated_by { get; set; }
        public virtual rol01role rol01role { get; set; }
        public virtual fil03attach_document fil03attach_document { get; set; }

    }
}
