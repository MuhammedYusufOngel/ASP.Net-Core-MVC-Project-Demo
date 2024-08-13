using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryRepository:GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetAllOrderByCount()
        {
            Context context = new Context();
            using(var c = new Context())
            {
                return c.Categories.Where(x => x.CategoryCount >= 1).OrderByDescending(x => x.CategoryCount).ToList();
            }
        }
    }
}
