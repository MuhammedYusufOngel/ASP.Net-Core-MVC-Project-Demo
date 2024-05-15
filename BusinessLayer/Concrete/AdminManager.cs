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
    public class AdminManager : IAdminService
    {
        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void TRemove(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
