namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IRepositorioGestion<TEntidad,TEntidadID>
    : IAgregar<TEntidad>, ITransaccion
    {
         void Anular(TEntidadID entidaID);
    }
}