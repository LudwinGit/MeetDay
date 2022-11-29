namespace MeetDay.Dominio.Core.Interfaces.Repositories
{
    public interface IUserRepository<T,TId> : 
    IAdd<T>, IEdit<T>, IDelete<TId>, IList<T,TId>, ITransaction
    {
        T FindByUsername(string username);
    }
}