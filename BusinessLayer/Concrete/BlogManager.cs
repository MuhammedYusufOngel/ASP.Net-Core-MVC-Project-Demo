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

        public void AddBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllBlogs()
        {
            return blogdal.GetAll();
        }

        public Blog GetBlog(int id)
        {
            return blogdal.getById(id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return blogdal.GetListWithCategory();
        }

        public void RemoveBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
