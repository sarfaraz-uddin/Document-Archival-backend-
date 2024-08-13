using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentArchival.Models.DTO
{
    public class set05municipalityModel
    {
        public int set05uin { get; set; }
        public string set05code { get; set; }
        public byte set05type { get; set; }
        public string set05title { get; set; }
        public string set05remarks { get; set; }
        public string set05address { get; set; }
        public string set05telphone { get; set; }
        public bool set05status { get; set; }
        public bool set05deleted { get; set; }
        public byte set05set04uin { get; set; }
        public string districtTitle { get; set; }
    }

    public class set05municipalityModelCreateVm
    {
        public int set05uin { get; set; }
        public string set05code { get; set; }
        public byte set05type { get; set; }
        public string set05title { get; set; }
        public string set05remarks { get; set; }
        public string set05address { get; set; }
        public string set05telphone { get; set; }
        public bool set05status { get; set; }
        public bool set05deleted { get; set; }
        public byte set05set04uin { get; set; }
    }

}
