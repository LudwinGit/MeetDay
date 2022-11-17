namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IAgregar<TEntidad>
    {
         TEntidad Agregar(TEntidad entidad);
    }
}