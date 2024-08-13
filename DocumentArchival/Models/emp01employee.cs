using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DocumentArchival.Models
{
    public class emp01employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emp01uin { get; set; }
        public string emp01code { get; set; }
        [ForeignKey("des01designation")]
        public int emp01des01uin { get; set; }
        [ForeignKey("dep01department")]
        public int emp01dep01uin { get; set; }
        [ForeignKey("lvl01employee_level")]
        public int emp01lvl01uin { get; set; }
        [ForeignKey("bra01branches")]
        public int emp01bra01uin { get; set; }
        [ForeignKey("des02functional_title")]
        public int emp01des02uin { get; set; }
        public string emp01name { get; set; }
        public string emp01password { get; set; }
        public string emp01address { get; set; }
        public string emp01email { get; set; }
        public string emp01mobile { get; set; }
        public bool emp01status { get; set; }
        public bool emp01deleted { get; set; }
        public string emp01created_by { get; set; }
        public DateTime emp01created_at { get; set; }
        public string? emp01updated_by { get; set; }
        public DateTime? emp01updated_at { get; set; }
        public bool emp01is_on_leave { get; set; }
        public dep01department dep01department { get; set; }
        public bra01branches bra01branches { get; set; }
        public des01designation des01designation { get; set; }
        public lvl01employee_level lvl01employee_level { get; set; }
        public des02functional_title des02functional_title { get; set; }
        [JsonIgnore]
        public ICollection<rol01role> rol01roles { get; set; }
        public ICollection<fil08user_permission> fil08User_Permissions { get; set; }
    }
}
