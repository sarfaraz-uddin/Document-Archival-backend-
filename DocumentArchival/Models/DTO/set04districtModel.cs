using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentArchival.Models.DTO
{
    public class set04districtModel
    {
        public byte set04uin { get; set; }
        public string set04code { get; set; }
        public string set04title { get; set; }
        public string set04remarks { get; set; }
        public bool set04status { get; set; }
        public bool set04deleted { get; set; }
        public byte set04set03uin { get; set; }
        public string provinceTitle { get; set; }
    }

    public class set04districtModelCreateVm
    {
        public byte set04uin { get; set; }
        public string set04code { get; set; }
        public string set04title { get; set; }
        public string set04remarks { get; set; }
        public bool set04status { get; set; }
        public bool set04deleted { get; set; }
        public byte set04set03uin { get; set; }
        
    }
}
