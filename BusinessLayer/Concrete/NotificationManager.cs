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
    public class NotificationManager : INotificationService
    {
        INotificationDal notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            this.notificationDal = notificationDal;
        }

        public List<Notification> GetAll()
        {
            return notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Notification entity)
        {
            notificationDal.Add(entity);
        }

        public void TRemove(Notification entity)
        {
            notificationDal.Delete(entity);
        }

        public void TUpdate(Notification entity)
        {
            notificationDal.Update(entity);
        }
    }
}
