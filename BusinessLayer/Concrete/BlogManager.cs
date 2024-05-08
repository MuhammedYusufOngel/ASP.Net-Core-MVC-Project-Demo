using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            this.blogdal = blogdal;
        }

        public List<Blog> getLast3Blogs()
        {
            return blogdal.GetAll().Take(3).ToList();
        }

        public List<Blog> getBlogbyID(int id)
        {
            return blogdal.GetAll(x => x.BlogID == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return blogdal.GetAll(x => x.WriterID == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return blogdal.GetListWithCategory();
        }

        public void TAdd(Blog entity)
        {
            blogdal.Add(entity);
        }

        public void TRemove(Blog entity)
        {
            blogdal.Delete(entity);
        }

        public void TUpdate(Blog entity)
        {
            blogdal.Update(entity);
        }

        public List<Blog> GetAll()
        {
            return blogdal.GetAll();
        }

        public Blog GetById(int id)
        {
            return blogdal.getById(id);
        }

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            return blogdal.GetListWithCategoryByWriter(id);
        }
    }
}
