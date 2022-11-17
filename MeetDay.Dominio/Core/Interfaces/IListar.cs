namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IListar<TEntidad,TEntidadID>
    {
         List<TEntidad> Listar();
         TEntidad SeleccionarPorID(TEntidadID entidadID);
    }
}