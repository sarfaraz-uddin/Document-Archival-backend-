using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil05branch_permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil05uin { get; set; }
        [ForeignKey("bra01branches")]
        public int fil05bra01uin { get; set; }
        [ForeignKey("fil03attach_document")]
        public int fil05fil03uin {  get; set; }
        public EnumPermissionType fil05permission_type { get; set; }
        public DateTime fil05created_at { get; set; }
        public string fil05created_by { get; set; }
        public DateTime? fil05updated_at { get; set; }
        public string? fil05updated_by { get; set; }
        public virtual bra01branches bra01branches { get; set; }
        public virtual fil03attach_document fil03attach_document {  get; set; } 
    }
}
