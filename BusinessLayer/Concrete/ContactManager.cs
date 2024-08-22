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
	public class ContactManager : IContactService
	{
		IContactDal contactDal;

		public ContactManager(IContactDal contactDal)
		{
			this.contactDal = contactDal;
		}

		public void AddContact(Contact contact)
		{
			contactDal.Add(contact);
		}

		public List<Contact> GetAll()
		{
			return contactDal.GetAll();
		}

		public Contact GetById(int id)
		{
			return contactDal.getById(id);
		}

		public void TAdd(Contact entity)
		{
			throw new NotImplementedException();
		}

		public void TRemove(Contact entity)
		{
			contactDal.Delete(entity);
		}

		public void TUpdate(Contact entity)
		{
			throw new NotImplementedException();
		}
	}
}
