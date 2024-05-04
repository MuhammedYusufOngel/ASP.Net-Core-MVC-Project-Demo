using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactUserName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }

        public Contact(int contactId, string contactUserName, string contactMail, string contactSubject, string contactMessage, DateTime contactDate, bool contactStatus)
        {
            ContactId = contactId;
            ContactUserName = contactUserName;
            ContactMail = contactMail;
            ContactSubject = contactSubject;
            ContactMessage = contactMessage;
            ContactDate = contactDate;
            ContactStatus = contactStatus;
        }
    }
}
