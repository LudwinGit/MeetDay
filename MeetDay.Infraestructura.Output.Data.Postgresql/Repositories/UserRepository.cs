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
        public async Task<User> AddAsync(User entity)
        {
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            return _db.Users.ToList();
        }

        public User FindByEmail(string email)
        {
            return _db.Users
                    .Where(f => f.Email == email)
                    .FirstOrDefault();
        }

        public async Task<User> FindById(int id)
        {
            return await _db.Users.FindAsync(id);
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

        public async Task<User> ListById(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
                throw new NotFoundException("User not found!");
            return user;
        }
    }
}