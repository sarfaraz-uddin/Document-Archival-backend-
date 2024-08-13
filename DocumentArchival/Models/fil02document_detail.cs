using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DocumentArchival.Models
{
    public class fil02document_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fil02uin { get; set; }
        [ForeignKey("fil01document_summary")]
        public int fil02fil01uin { get; set; }
        public string fil02doctitle {  get; set; }
        [ForeignKey("fil09document_type")]
        public int fil02fil09uin { get; set; }
        [ForeignKey("fil10document_category")]
        public int fil02fil10uin { get; set; }
        public DateTime fil02expirydate { get; set; }
        public bool fil02isconfidential { get; set; }
        public string fil02version { get; set; }
        public string fil02description { get; set; }
        public string fil02docphysicallocation { get; set; }
        public DateTime fil02created_at { get; set; }
        public string file02created_by { get; set; }
        public DateTime? fil02updated_at { get; set; }
        public string? file02updated_by { get; set; }
        public ICollection<fil04tag> fil04Tags { get; set; }
        public virtual fil01document_summary fil01document_summary { get; set;}
        public virtual fil09document_type fil09document_type { get; set; }
        public virtual fil10document_category fil10document_category { get; set; }
        public ICollection<fil03attach_document> fil03attach_documents { get; set; }
    }
}
