namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IEdit<T>
    {
         Task<int> Edit(T entity);
    }
}