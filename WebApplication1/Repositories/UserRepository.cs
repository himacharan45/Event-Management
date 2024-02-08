using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Contexts;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : IRepository<string, Users>
    {
        private readonly EventContext _context;
        public UserRepository( EventContext context) { 
        _context= context;
        }
        public Users Add(Users entity)
        {
            _context.users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Users Delete(string Key)
        {

            var user = GetById(Key);
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

            public IList<Users> GetAll()
            {
                if (_context.users.Count() == 0)
                    return null;
                return _context.users.ToList();
            }


        public Users GetById(string Key)
        {
            var user = _context.users.SingleOrDefault(u => u.Username == Key);
            return user;
        }

        public Users Update(Users entity)
        {
            var user = GetById(entity.Username);
            if (user != null)
            {
                _context.Entry<Users>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }
}
