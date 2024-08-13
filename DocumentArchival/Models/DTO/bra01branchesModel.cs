namespace DocumentArchival.Models.DTO
{
    public class bra01branchesModel
    {
        public int bra01uin { get; set; }
        public string bra01name { get; set; }
        public string bra01address { get; set; }
        public string bra01telephone { get; set; }
        public bool bra01status { get; set; }
        public bool bra01deleted { get; set; }
        public string bra01code { get; set; }
        public int bra01set05uin_muncipality { get; set; }
        public bool bra01is_head_office { get; set; }
        public string municipalityTitle { get; set; }
    }
    public class bra01branchesModelCreateVm
    {
        public int bra01uin { get; set; }
        public string bra01name { get; set; }
        public string bra01address { get; set; }
        public string bra01telephone { get; set; }
        public bool bra01status { get; set; }
        public bool bra01deleted { get; set; }
        public string bra01code { get; set; }
        public int bra01set05uin_muncipality { get; set; }
        public bool bra01is_head_office { get; set; }
    }
}
