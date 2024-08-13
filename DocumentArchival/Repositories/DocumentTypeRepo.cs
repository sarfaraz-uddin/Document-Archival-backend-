using DocumentArchival.Data;
using DocumentArchival.Interface;
using DocumentArchival.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class DocumentTypeRepo : GenericRepo<fil09document_type>, IDocumentTypeRepo
    {
        public DocumentTypeRepo(ApplicationDbContext context) : base(context) 
        {
        }
    }
}
