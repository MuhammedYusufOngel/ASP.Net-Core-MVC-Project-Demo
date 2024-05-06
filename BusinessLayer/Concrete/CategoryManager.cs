using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            categoryDal.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return categoryDal.GetAll();
        }

        public Category GetCategory(int id)
        {
            return categoryDal.getById(id);
        }

        public void RemoveCategory(Category category)
        {
            categoryDal.Delete(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryDal.Update(category);
        }
    }
}
