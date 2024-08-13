using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil06department_permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil06uin { get; set; }
        [ForeignKey("dep01department")]
        public int fil06dep01uin { get; set; }
        [ForeignKey("fil03attach_document")]
        public int fil06fil03uin { get; set; }
        public EnumPermissionType fil06permission_type { get; set; }
        public DateTime fil06created_at { get; set; }
        public string fil06created_by { get; set; }
        public DateTime? fil06updated_at { get; set; }
        public string? fil06updated_by { get; set; }
        public virtual dep01department dep01department { get; set; }
        public virtual fil03attach_document fil03attach_document { get; set; }

    }
}
