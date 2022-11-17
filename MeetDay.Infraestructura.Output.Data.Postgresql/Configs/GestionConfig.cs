
using MeetDay.Dominio.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Configs
{
    public class GestionConfig : IEntityTypeConfiguration<Gestion>
    {
        public void Configure(EntityTypeBuilder<Gestion> builder)
        {
            builder.ToTable("gestion");
            builder.HasKey(e=>e.gestionId);
        }
    }
}