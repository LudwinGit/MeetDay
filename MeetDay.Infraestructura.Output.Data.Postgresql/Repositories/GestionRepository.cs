using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class GestionRepository : IRepositorioBase<Gestion, Guid>
    {
        private readonly MeetDayContext _meetDayContext;
        public GestionRepository(MeetDayContext meetDayContext)
        {
            _meetDayContext = meetDayContext;
        }
        public Gestion Agregar(Gestion entidad)
        {
            entidad.gestionId = Guid.NewGuid();
            _meetDayContext.Gestions.Add(entidad);
            return entidad;
        }

        public void Editar(Gestion entidad)
        {
            var gestion = _meetDayContext.Gestions.Find(entidad.gestionId);
            if(gestion != null){
                gestion.estado = entidad.estado;
                gestion.nombre = entidad.nombre;
                _meetDayContext.Entry(gestion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Gestion entidadId)
        {
            throw new NotImplementedException();
        }

        public void GuardarTodosLosCambios()
        {
            _meetDayContext.SaveChanges();
        }

        public List<Gestion> Listar()
        {
            throw new NotImplementedException();
        }

        public Gestion SeleccionarPorID(Guid entidadID)
        {
            throw new NotImplementedException();
        }
    }
}