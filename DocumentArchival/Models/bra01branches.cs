using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class bra01branches
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bra01uin { get; set; }
        public string bra01name { get; set; }
        public string bra01address { get; set; }
        public string bra01telephone { get; set; }
        public bool bra01status { get; set; }
        public bool bra01deleted { get; set; }
        public string bra01code { get; set; }
        public string bra01created_by { get; set; }
        public DateTime bra01created_at { get; set; }
        public string? bra01updated_by { get; set; }
        public DateTime? bra01updated_at { get; set; }
        [ForeignKey("set05municipality")]
        public int bra01set05uin_muncipality { get; set; }
        public bool bra01is_head_office { get; set; }
        public ICollection<emp01employee> emp01employees { get; set; }
        public ICollection<fil01document_summary> fil01document_summaries { get; set; }
        public ICollection<fil05branch_permission> fil05branch_permissions { get; set; }
        public set05municipality set05municipality { get; set; }
    }
}
