using MeetDay.Dominio.Core.Interfaces;
namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface IBaseService<TEntidad, TEntidadID>
    : IAgregar<TEntidad>, IEditar<TEntidad> ,IEliminar<TEntidad>, IListar<TEntidad,TEntidadID>
    {
         
    }
}