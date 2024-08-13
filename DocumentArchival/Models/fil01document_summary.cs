using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentArchival.Models
{
    public class fil01document_summary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil01uin { get; set; }
        [ForeignKey ("bra01branches")]
        public int fil01bra01uin { get; set; }
        [ForeignKey("dep01department")]
        public int fil01dep01uin { get; set; }
        public string fil01owner { get; set; }
        public DateTime fil01created_at { get; set; }
        public string file01created_by { get; set; }
        public DateTime? fil01updated_at { get; set; }
        public string? file01updated_by { get; set; }
        public virtual bra01branches bra01branches { get; set; }
        public virtual dep01department dep01department { get; set; }
        public ICollection<fil02document_detail> fil02document_details { get; set; }
    }
}
