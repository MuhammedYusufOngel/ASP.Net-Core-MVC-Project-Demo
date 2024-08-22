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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            this.message2Dal = message2Dal;
        }

        public List<Message2> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message2 GetById(int id)
        {
            return message2Dal.getById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return message2Dal.GetInBoxWithMessageByWriter(id);
        }
        public List<Message2> GetSendboxListByWriter(int id)
        {
            return message2Dal.GetSendBoxWithMessageByWriter(id);
        }

        public void TAdd(Message2 entity)
        {
            message2Dal.Add(entity);
        }

        public void TRemove(Message2 entity)
        {
            message2Dal.Delete(entity);
        }

        public void TUpdate(Message2 entity)
        {
            message2Dal.Update(entity);
        }
    }
}
