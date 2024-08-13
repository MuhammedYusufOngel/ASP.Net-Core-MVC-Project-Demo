using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList : ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EFCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = cm.GetAllOrderByCount();
			return View(values);
		}
	}
}
