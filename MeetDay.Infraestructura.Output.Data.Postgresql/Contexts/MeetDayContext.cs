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
        // public DbSet<Management> Managements {get;set;}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfig());
            // builder.ApplyConfiguration(new ManagementConfig());
        }
    }
}