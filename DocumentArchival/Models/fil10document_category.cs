using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentArchival.Models
{
    public class fil10document_category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil10uin { get; set; }
        [ForeignKey("fil09document_type")]
        public int fil10fil09uin { get; set; }
        public string fil10title { get; set; }
        public DateTime fil10created_at { get; set; }
        public string fil10created_by { get; set; }
        public DateTime? fil10updated_at { get; set; }
        public string? fil10updated_by { get; set; }
        public virtual fil09document_type fil09document_type { get; set; }
        public ICollection<fil02document_detail> fil02document_details { get; set; }
    }
}
