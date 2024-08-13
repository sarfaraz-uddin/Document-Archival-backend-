using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class lvl01employee_level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lvl01uin { get; set; }
        public string lvl01title { get; set; }
        public string lvl01description { get; set; }
        public string lvl01code { get; set; }
        public bool lvl01status { get; set; }
        public bool lvl01deleted { get; set; }
        public string lvl01created_by { get; set; }
        public DateTime lvl01created_at { get; set; }
        public string? lvl01updated_by { get; set; }
        public DateTime? lvl01updated_at { get; set; }
        public ICollection<emp01employee> emp01employees { get; set; }
    }
}
