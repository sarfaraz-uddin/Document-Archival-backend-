using DocumentArchival.Data;
using DocumentArchival.Interface;
using DocumentArchival.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class DocumentCategoryRepo : GenericRepo<fil10document_category> , IDocumentCategoryRepo
    {
        public DocumentCategoryRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
