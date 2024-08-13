using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil03attach_document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil03uin { get; set; }
        [ForeignKey("fil02document_detail")]
        public int fil03fil02uin { get; set; }
        public string fil03name { get; set; }
        public string fil03size { get; set; }
        public string file03path { get; set; }
        public DateTime fil03created_at { get; set; }
        public string fil03created_by { get; set; }
        public DateTime? fil03updated_at { get; set; }
        public string? file03updated_by { get; set; }
        public virtual fil02document_detail fil02document_detail { get; set; }
        public ICollection<fil05branch_permission> fil05branch_permissions { get; set; }
        public ICollection<fil06department_permission> fil06department_permissions { get; set; }
        public ICollection<fil07role_permission> fil07role_permissions { get; set; }
        public ICollection<fil08user_permission> fil08user_permissions { get; set; }
    }
}
