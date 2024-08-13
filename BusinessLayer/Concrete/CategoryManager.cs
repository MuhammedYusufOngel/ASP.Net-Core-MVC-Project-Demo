using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll();
        }

        public List<Category> GetAllOrderByCount()
        {
            return categoryDal.GetAllOrderByCount();
        }

        public Category GetById(int id)
        {
            return categoryDal.getById(id);
        }

        public void TAdd(Category entity)
        {
            categoryDal.Add(entity);
        }

        public void TRemove(Category entity)
        {
            categoryDal.Delete(entity);
        }

        public void TUpdate(Category entity)
        {
            categoryDal.Update(entity);
        }
    }
}
