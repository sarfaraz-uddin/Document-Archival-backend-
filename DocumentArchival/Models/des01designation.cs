using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DocumentArchival.Models
{
    public class des01designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int des01uin { get; set; }
        public string des01code { get; set; }
        public string des01title { get; set; }
        public string des01description { get; set; }
        public bool des01status { get; set; }
        public bool des01deleted { get; set; }
        public string des01created_by { get; set; }
        public DateTime des01created_at { get; set; }
        public string? des01updated_by { get; set; }
        public DateTime? des01updated_at { get; set; }
        public ICollection<emp01employee> emp01employees { get; set; }
    }
}
