namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IEdit<T>
    {
        int Edit(T entity);
    }
}