using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutDetails1 { get; set; }
        public string AboutDetails2 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
        public string AboutMapLocation { get; set; }
        public bool AboutStatus { get; set; }

        public About(int aboutID, string aboutDetails1, string aboutDetails2, string aboutImage1, string aboutImage2, string aboutMapLocation, bool aboutStatus)
        {
            AboutID = aboutID;
            AboutDetails1 = aboutDetails1;
            AboutDetails2 = aboutDetails2;
            AboutImage1 = aboutImage1;
            AboutImage2 = aboutImage2;
            AboutMapLocation = aboutMapLocation;
            AboutStatus = aboutStatus;
        }
    }
}
