namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
         void Eliminar(TEntidadID entidadId);
    }
}