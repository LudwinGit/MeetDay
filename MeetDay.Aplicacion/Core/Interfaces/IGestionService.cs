using MeetDay.Dominio.Core.Interfaces;
namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface IGestionService<TEntidad,TEntidadID>
    : IAgregar<TEntidad>, IListar<TEntidad,TEntidad>
    {
        void Anular(TEntidadID entidaID);
    }
}