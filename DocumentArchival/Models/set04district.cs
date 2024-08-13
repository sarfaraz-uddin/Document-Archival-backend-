using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class set04district
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte set04uin { get; set; }
        [ForeignKey("set03province")]
        public byte set04set03uin { get; set; }
        public string set04code { get; set; }
        public string set04title { get; set; }
        public string set04remarks { get; set; }
        public bool set04status { get; set; }
        public bool set04deleted { get; set; }
        public string set04created_by { get; set; }
        public DateTime set04created_at { get; set; }
        public string? set04updated_by { get; set; }
        public DateTime? set04updated_at { get; set; }
        public virtual ICollection<set05municipality> set05municipalitys { get; set; }
        public virtual set03province set03province { get; set; }
    }
}
