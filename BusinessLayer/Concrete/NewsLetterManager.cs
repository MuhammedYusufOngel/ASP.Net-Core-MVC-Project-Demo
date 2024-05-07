using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal newsLetterDal;

		public NewsLetterManager(INewsLetterDal newsLetterDal)
		{
			this.newsLetterDal = newsLetterDal;
		}

		public void AddNewsLetter(NewsLetter newsLetter)
		{
			newsLetterDal.Add(newsLetter);
		}
	}
}
