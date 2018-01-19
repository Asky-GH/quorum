using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class QARepository : IRepository<QA>
    {
        private Context _context;

        public QARepository(Context context)
        {
            _context = context;
        }

        public void Create(QA entity)
        {
            _context.QAs.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(QA entity)
        {
            _context.QAs.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<QA> GetAll()
        {
            return _context.QAs;
        }

        public void Update(QA entity)
        {
            QA qa = _context.QAs.Find(entity.Id);
            qa = entity;
            _context.SaveChanges();
        }
    }
}
