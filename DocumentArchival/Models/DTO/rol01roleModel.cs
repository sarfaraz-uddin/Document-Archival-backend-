using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentArchival.Models.DTO
{
    public class rol01roleModel
    {
        public int rol01uin { get; set; }
        public int rol01emp01uin { get; set; }
        public string rol01title { get; set; }
        public bool rol01deleted { get; set; }
    }
}
