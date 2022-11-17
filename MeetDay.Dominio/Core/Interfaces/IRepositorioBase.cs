namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IRepositorioBase<TEntidad,TEntidadID> 
    : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
         
    }
}