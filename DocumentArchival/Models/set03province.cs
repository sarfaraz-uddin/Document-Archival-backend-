using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class set03province
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte set03uin { get; set; }
        public string set03code { get; set; }
        public string set03title { get; set; }
        public string set03remarks { get; set; }
        public bool set03status { get; set; }
        public bool set03deleted { get; set; }
        public string set03created_by { get; set; }
        public DateTime set03created_at { get; set; }
        public string? set03updated_by { get; set; }
        public DateTime? set03updated_at { get; set; }
        public ICollection<set04district> set04districts { get; set; }
    }
}
