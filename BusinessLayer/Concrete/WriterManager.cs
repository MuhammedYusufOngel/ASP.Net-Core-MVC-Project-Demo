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
	public class WriterManager : IWriterService
	{
		IWriterDal writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			this.writerDal = writerDal;
		}

		public List<Writer> GetAll()
		{
			throw new NotImplementedException();
		}

		public Writer GetById(int id)
		{
			return writerDal.getById(id);
		}

		public List<Writer> GetWriterById(int id)
		{
			return writerDal.GetAll(x => x.WriterID == id);
		}

		public void TAdd(Writer entity)
		{
			writerDal.Add(entity);
		}

		public void TRemove(Writer entity)
		{
			writerDal.Delete(entity);
		}

		public void TUpdate(Writer entity)
		{
			writerDal.Update(entity);
		}
	}
}
