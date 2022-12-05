
using MeetDay.Dominio.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Configs
{
    public class ManagementConfig : IEntityTypeConfiguration<Management>
    {
        public void Configure(EntityTypeBuilder<Management> builder)
        {
            builder.HasKey(e=>e.Id);
        }
    }
}