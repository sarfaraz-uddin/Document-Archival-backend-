using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil04tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil04uin { get; set; }
        public string fil04title { get; set; }
        [ForeignKey("fil02document_detail")]
        public int? fil04fil02uin { get; set; }
        public DateTime fil04created_at { get; set; }
        public string fil04created_by { get; set; }
        public DateTime? fil04updated_at { get; set; }
        public string? fil04updated_by { get; set; }
        public virtual fil02document_detail fil02document_detail { get; set;}
    }
}
