namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IList<T,TId>
    {
         List<T> FindAll();
         Task<T> FindById(TId Id);
    }
}