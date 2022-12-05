namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IAdd<T>
    {
         Task<T> AddAsync(T entity);
    }
}