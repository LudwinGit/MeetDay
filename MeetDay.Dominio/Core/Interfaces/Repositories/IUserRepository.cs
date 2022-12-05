namespace MeetDay.Dominio.Core.Interfaces.Repositories
{
    public interface IUserRepository<T,TId> : 
    IAdd<T>, IEdit<T>, IDelete<T>, IList<T,TId>
    {
        T FindByUsername(string username);
        T FindByEmail(string email);
    }
}