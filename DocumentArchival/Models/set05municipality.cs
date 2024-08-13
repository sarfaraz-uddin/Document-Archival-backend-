using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class set05municipality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int set05uin { get; set; }
        [ForeignKey("set04district")]
        public byte set05set04uin { get; set; }
        public string set05code { get; set; }
        public byte set05type { get; set; }
        public string set05title { get; set; }
        public string set05remarks { get; set; }
        public string set05address { get; set; }
        public string set05telphone { get; set; }
        public bool set05status { get; set; }
        public bool set05deleted { get; set; }
        public string set05created_by { get; set; }
        public DateTime set05created_at { get; set; }
        public string? set05updated_by { get; set; }
        public DateTime? set05updated_at { get; set; }
        public ICollection<bra01branches> bra01branches { get; set; }
        public set04district set04district { get; set; }

    }
}
