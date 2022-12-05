namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IDelete<T>
    {
         void Delete(T entity);
    }
}