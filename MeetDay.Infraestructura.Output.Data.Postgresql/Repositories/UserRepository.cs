using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Exceptions;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class UserRepository : IUserRepository<User, int>
    {
        private readonly MeetDayContext _db;
        public UserRepository(MeetDayContext db)
        {
            _db = db;
        }
        public User Add(User Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User Entity)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            return _db.Users.ToList();
        }

        public async Task<User> FindById(int Id)
        {
            return await _db.Users.FindAsync(Id);
        }

        public User FindByUsername(string username)
        {
            return _db.Users
                    .Where(f => f.Username == username.ToLower())
                    .FirstOrDefault();
        }

        public Task<List<User>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<User> ListById(int Id)
        {
            var user = await _db.Users.FindAsync(Id);
            if (user == null)
                throw new NotFoundException("User not found!");
            return user;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}