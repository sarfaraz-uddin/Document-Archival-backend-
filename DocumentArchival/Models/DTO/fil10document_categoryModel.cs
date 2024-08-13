using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentArchival.Models.DTO
{
    public class fil10document_categoryModel
    {
        public string fil10title { get; set; }
        public DateTime fil10created_at { get; set; }
        public string fil10created_by { get; set; }
        public DateTime? fil10updated_at { get; set; }
        public string? fil10updated_by { get; set; }
        public int fil10fil09uin { get; set; }
   }
    public class fil10document_categoryUpdateModel
    {
        public int fil10uin { get; set; }
        public int fil10fil09uin { get; set; }
        public string fil10title { get; set; }
        public DateTime fil10created_at { get; set; }
        public string fil10created_by { get; set; }
        public DateTime? fil10updated_at { get; set; }
        public string? fil10updated_by { get; set; }
    }
}
