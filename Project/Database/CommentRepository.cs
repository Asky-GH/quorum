using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class CommentRepository : IRepository<Comment>
    {
        private Context _context;

        public CommentRepository(Context context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public void Update(Comment entity)
        {
            Comment comment = _context.Comments.Find(entity.Id);
            comment = entity;
            _context.SaveChanges();
        }
    }
}
