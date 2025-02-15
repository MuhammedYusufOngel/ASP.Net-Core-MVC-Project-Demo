﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
                return c.Blogs.Include(c => c.Category).OrderByDescending(x => x.BlogID).ToList();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
                return c.Blogs.Include(c => c.Category).OrderBy(x => x.BlogID).Where(x => x.WriterID == id).ToList();
        }
    }
}
