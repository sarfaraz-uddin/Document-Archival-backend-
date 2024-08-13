using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentArchival.Models.DTO
{
    public class emp01employeeModel
    {
        public int emp01uin { get; set; }
        public string emp01code { get; set; }
        public int emp01des01uin { get; set; }
        public int emp01dep01uin { get; set; }
        public int emp01lvl01uin { get; set; }
        public int emp01bra01uin { get; set; }
        public int emp01des02uin { get; set; }
        public string emp01name { get; set; }
        public string emp01password { get; set; }
        public string emp01address { get; set; }
        public string emp01email { get; set; }
        public string emp01mobile { get; set; }
        public bool emp01status { get; set; }
        public bool emp01deleted { get; set; }
        public bool emp01is_on_leave { get; set; }
    }
}
