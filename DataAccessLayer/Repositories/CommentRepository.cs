using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : IGenericDal<Comment>
    {
        Context c = new Context();

        public void Add(Comment item)
        {
            c.Add(item);
            c.SaveChanges();
        }

        public void Delete(Comment item)
        {
            c.Remove(item);
            c.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return c.Comments.ToList();
        }

        public Comment getById(int id)
        {
            return c.Comments.Find(id);
        }

        public void Update(Comment item)
        {
            c.Update(item);
            c.SaveChanges();
        }
    }
}
