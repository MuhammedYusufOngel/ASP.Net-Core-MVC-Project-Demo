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
    public class MessageManager : IMessageService
    {
        IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public List<Message> GetAll()
        {
            return messageDal.GetAll();
        }

        public Message GetById(int id)
        {
            return messageDal.getById(id);
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return messageDal.GetAll(x => x.Receiver == p);
        }

        public void TAdd(Message entity)
        {
            messageDal.Add(entity);
        }

        public void TRemove(Message entity)
        {
            messageDal.Delete(entity);
        }

        public void TUpdate(Message entity)
        {
            messageDal.Update(entity);
        }
    }
}
