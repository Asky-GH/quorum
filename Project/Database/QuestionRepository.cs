using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class QuestionRepository : IRepository<Question>
    {
        private Context _context;

        public QuestionRepository(Context context)
        {
            _context = context;
        }

        public void Create(Question entity)
        {
            _context.Questions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Question entity)
        {
            _context.Questions.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Question> GetAll()
        {
            return _context.Questions;
        }

        public void Update(Question entity)
        {
            Question question = _context.Questions.Find(entity.Id);
            question = entity;
            _context.SaveChanges();
        }
    }
}
