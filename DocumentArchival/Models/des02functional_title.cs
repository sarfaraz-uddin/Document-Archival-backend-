using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class des02functional_title
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int des02uin { get; set; }
        public string des02code { get; set; }
        public string des02title { get; set; }
        public string des02remarks { get; set; }
        public bool des02status { get; set; }
        public bool des02deleted { get; set; }
        public string des02created_by { get; set; }
        public DateTime des02created_at { get; set; }
        public string? des02updated_by { get; set; }
        public DateTime? des02updated_at { get; set; }
        public ICollection<emp01employee> emp01employees { get; set; }
    }
}
