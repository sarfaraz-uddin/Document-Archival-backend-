namespace DocumentArchival.Models.DTO
{
    public class fil09document_typeModel
    {
        public string fil09title { get; set; }
        public DateTime fil09created_at { get; set; }
        public string fil09created_by { get; set; }
        public DateTime? fil09updated_at { get; set; }
        public string? fil09updated_by { get; set; }
    }
    public class fil09document_typeUpdateModel
    {
        public int fil09uin { get; set; }
        public string fil09title { get; set; }
        public DateTime fil09created_at { get; set; }
        public string fil09created_by { get; set; }
        public DateTime? fil09updated_at { get; set; }
        public string? fil09updated_by { get; set; }
    }
}
