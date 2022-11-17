using MeetDay.Dominio.Core.Entity;
using MeetDay.Infraestructura.Output.Data.Postgresql.Configs;
using Microsoft.EntityFrameworkCore;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Contexts
{
    public class MeetDayContext : DbContext
    {
        public DbSet<Gestion> Gestions {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseNpgsql("");
        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GestionConfig());
        }
    }
}