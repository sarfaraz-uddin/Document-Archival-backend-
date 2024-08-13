using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DocumentArchival.Models
{
    public class rol01role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rol01uin { get; set; }
        [ForeignKey("emp01employee")]
        public int rol01emp01uin { get; set; }
        public string rol01title { get; set; }
        public bool rol01deleted { get; set; }
        public DateTime rol01created_at { get; set; }   
        public string rol01created_by { get; set; }
        public DateTime? rol01updated_at { get; set; }
        public string? rol01updated_by { get;set; }
        public virtual emp01employee emp01employee { get; set; }
        public ICollection<fil07role_permission> fil07Role_Permissions { get; set; }

    }
}
