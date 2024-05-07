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
	public class AboutManager : IAboutService
	{
		IAboutDal aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			this.aboutDal = aboutDal;
		}

		public List<About> GetAbouts()
		{
			return aboutDal.GetAll();
		}
	}
}
