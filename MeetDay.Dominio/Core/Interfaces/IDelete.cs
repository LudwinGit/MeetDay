namespace MeetDay.Dominio.Core.Interfaces
{
    public interface IDelete<TId>
    {
         void Delete(TId Id);
    }
}