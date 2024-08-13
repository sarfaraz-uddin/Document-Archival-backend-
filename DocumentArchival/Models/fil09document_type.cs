using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class fil09document_type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil09uin { get; set; }
        public string fil09title { get; set; }
        public DateTime fil09created_at { get; set; }
        public string fil09created_by { get; set; }
        public DateTime? fil09updated_at { get; set; }
        public string? fil09updated_by { get; set; }
        public ICollection<fil02document_detail> fil02document_details { get; set; }
        public ICollection<fil10document_category> fil10Document_Categories { get; set; }
    }
}
