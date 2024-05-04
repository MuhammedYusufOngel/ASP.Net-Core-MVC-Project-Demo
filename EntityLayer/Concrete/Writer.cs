using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }

        public Writer(int writerID, string writerName, string writerAbout, string writerImage, string writerMail, string writerPassword, bool writerStatus)
        {
            WriterID = writerID;
            WriterName = writerName;
            WriterAbout = writerAbout;
            WriterImage = writerImage;
            WriterMail = writerMail;
            WriterPassword = writerPassword;
            WriterStatus = writerStatus;
        }
    }
}
