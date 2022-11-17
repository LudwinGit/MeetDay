using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces;

namespace MeetDay.Aplicacion.Core.Services
{
    public class GestionService : IGestionService<Gestion, Guid>
    {
        private readonly IRepositorioBase<Gestion,Guid> _repoProducto;
        public GestionService(IRepositorioBase<Gestion,Guid> repoProducto)
        {
            _repoProducto = repoProducto;
        }
        public Gestion Agregar(Gestion entidad)
        {
            if(entidad == null)
                throw new ArgumentNullException("La 'Gestion' es requerida");
            var resultado = _repoProducto.Agregar(entidad);
            _repoProducto.GuardarTodosLosCambios();
            return resultado;
        }

        public void Anular(Guid entidaID)
        {
            throw new NotImplementedException();
        }

        public List<Gestion> Listar()
        {
            throw new NotImplementedException();
        }

        public Gestion SeleccionarPorID(Gestion entidadID)
        {
            throw new NotImplementedException();
        }
    }
}