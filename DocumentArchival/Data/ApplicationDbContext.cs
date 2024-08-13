using DocumentArchival.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<set03province> set03provinces { get; set; }
        public DbSet<bra01branches> bra01branches { get; set; }
        public DbSet<dep01department> dep01departments { get; set; }
        public DbSet<des01designation> des01designations { get; set; }
        public DbSet<des02functional_title> des02functional_titles {  get; set; }
        public DbSet<emp01employee> emp01employees { get; set; }
        public DbSet<lvl01employee_level> lvl01employee_levels { get; set; }
        public DbSet<set04district> set04districts { get; set; }
        public DbSet<set05municipality> set05municipalities { get; set; }
        public DbSet<fil01document_summary> fil01document_summaries { get; set; }
        public DbSet<fil02document_detail> fil02Document_Details { get; set; }
        public DbSet<fil03attach_document> fil03attach_documents { get; set; }
        public DbSet<fil04tag> fil04tags { get; set; }
        public DbSet<fil05branch_permission> fil05branch_permissions { get; set; }
        public DbSet<fil06department_permission> fil06department_permissions {  get; set; }
        public DbSet<fil07role_permission> fil07role_permissions { get; set; }
        public DbSet<fil08user_permission> fil08User_Permissions { get; set; }
        public DbSet<rol01role> rol01roles {  get; set; }
        public DbSet<fil10document_category> fil10document_categories { get; set; }
        public DbSet<fil09document_type> fil09document_types { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
