using MeetDay.Dominio.Core.Entity;
using MeetDay.Infraestructura.Output.Data.Postgresql.Configs;
using Microsoft.EntityFrameworkCore;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Contexts
{
    public class MeetDayContext : DbContext
    {
        public MeetDayContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Management> Managements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CatalogDocument> CatalogDocuments { get; set; }
        public DbSet<DocumentManagement> DocumentManagements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentManagement>(x =>
           {
               x.HasKey(x => new { x.CatalogDocumentId, x.ManagementId });
           });
            base.OnModelCreating(modelBuilder);
        }
    }
}