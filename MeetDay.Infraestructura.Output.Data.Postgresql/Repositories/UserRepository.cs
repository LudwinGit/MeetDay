using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Exceptions;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class UserRepository : IUserRepository<User, int>
    {
        private readonly MeetDayContext _context;
        public UserRepository(MeetDayContext db)
        {
            _context = db;
        }
        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public User FindByEmail(string email)
        {
            return _context.Users
                    .Where(f => f.Email == email)
                    .FirstOrDefault();
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public User FindByUsername(string username)
        {
            return _context.Users
                    .Where(f => f.Username == username.ToLower())
                    .FirstOrDefault();
        }

        public Task<List<User>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<User> ListById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new NotFoundException("User not found!");
            return user;
        }
    }
}