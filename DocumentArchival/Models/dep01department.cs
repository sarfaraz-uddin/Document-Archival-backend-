using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class dep01department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dep01uin { get; set; }
        public string dep01title { get; set; }
        public string dep01code { get; set; }
        public bool dep01status { get; set; }
        public bool dep01deleted { get; set; }
        public string dep01created_by { get; set; }
        public DateTime dep01created_at { get; set; }
        public string? dep01updated_by { get; set; }
        public DateTime? dep01updated_at { get; set; }
        public ICollection<emp01employee> emp01employees { get; set; }
        public ICollection<fil01document_summary> fil01document_summaries { get; set; }
        public ICollection<fil06department_permission> fil06department_permissions { get; set; }


    }
}
