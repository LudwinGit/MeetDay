namespace MeetDay.Dominio.Core.Interfaces.Repositories
{
    public interface IManagementDocumentRepository<T, TId> :
    IAdd<T>, IEdit<T>, IDelete<T>, IList<T, TId>
    {

    }
}