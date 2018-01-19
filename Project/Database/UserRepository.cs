using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class UserRepository : IRepository<User>
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public void Update(User entity)
        {
            User user = _context.Users.Find(entity.Id);
            user = entity;
            _context.SaveChanges();
        }
    }
}
